// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

namespace CloudStack.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Client session to CloudStack API server.
    /// </summary>
    public partial class Client : IDisposable
    {
        #region Fields
        /// <summary>
        /// Default rate at which the SDK will poll for async job resulst etc.
        /// </summary>
        private readonly TimeSpan DefaultPollRate = TimeSpan.FromSeconds(2);

        /// <summary>
        /// Default timeout for HTTP requests to the API server
        /// </summary>
        private readonly TimeSpan DefaultRequestTimeout = TimeSpan.FromMinutes(2);

        /// <summary>
        /// Unix time starts January 1st 1970
        /// </summary>
        private DateTime UnixBaseTime = new DateTime(1970, 1, 1);

        private string apiKey;

        private SecureString secretKey;

        private string cloudStackVersion;

        private CookieContainer cookieContainer;

        private string sessionKey;

        private bool disposed;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Client class.  Used to hold connection information.
        /// </summary>
        /// <param name="apiUrl">Url for CloudStack API, e.g. http://myserver.cloud.com/client/api</param>
        /// <param name="apiKey">API Key (not user name)</param>
        /// <param name="ssoKey">secret key (not password)</param>
        /// <param name="requestTimeout">timeout for HTTP requests to API server</param>
        /// <param name="pollRate">Rate to query for aync job completion</param>
        /// <remarks>
        /// Number of concurrent connections to a server is governed by the 
        /// System.Net.ServicePointManager.DefaultConnectionLimit property.  Set this to a value
        /// that reflects the number of threads that will be operating the API at any given time.
        /// </remarks>
        public Client(Uri apiUrl, string apiKey, SecureString secretKey, TimeSpan requestTimeout, TimeSpan pollRate)
        {
            this.ApiAddress = apiUrl;
            this.apiKey = apiKey;
            this.secretKey = (secretKey == null) ? null : secretKey.Copy();
            this.HttpRequestTimeout = (requestTimeout == TimeSpan.Zero) ? DefaultRequestTimeout : requestTimeout;
            this.CloudPollRate = (pollRate == TimeSpan.Zero) ? DefaultPollRate : pollRate;
        }

        /// <summary>
        /// Initializes a new instance of the Client class.  
        /// </summary>
        /// <param name="apiUrl">Url for CloudStack API</param>
        /// <param name="apiKey">API Key (not the account id)</param>
        /// <param name="ssoKey">secret key (not the account password)</param>
        public Client(Uri apiUrl, string apiKey, SecureString secretKey) :
            this(apiUrl, apiKey, secretKey, TimeSpan.Zero, TimeSpan.Zero)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Client class.  
        /// </summary>
        /// <param name="apiUrl">Url for CloudStack API</param>
        /// <param name="apiKey">API Key (not the account id)</param>
        /// <param name="ssoKey">secret key (not the account password)</param>
        public Client(Uri apiUrl, string apiKey, string secretKey) :
            this(apiUrl, apiKey, CreateSecureString(secretKey), TimeSpan.Zero, TimeSpan.Zero)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Client class.  
        /// </summary>
        /// <param name="apiUrl">Url for CloudStack API</param>
        /// <param name="sessionKey">session key</param>
        /// <param name="sessionCookie">session cookie)</param>
        public Client(Uri apiUrl, string sessionKey, Cookie  sessionCookie) :
            this(apiUrl) 
        { 
            this.sessionKey = sessionKey;
            this.cookieContainer = new CookieContainer();
            this.cookieContainer.Add(sessionCookie);
        }

        /// <summary>
        /// Initializes a new instance of the Client class. 
        /// </summary>
        /// <param name="apiUrl"></param>
        public Client(Uri apiUrl)
            : this(apiUrl, null, (SecureString)null)
        {      
        }

        #endregion

        #region Properties

        /// <summary>
        /// Url for CloudStack API
        /// </summary>
        public Uri ApiAddress
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the version string from the CloudStack API. This value is retrieved once and 
        /// cached in the client session.
        /// </summary>
        public string CloudStackVersion
        {
            get
            {
                if (cloudStackVersion == null)
                {
                    // Any query will do...
                    ListNetworksRequest request = new ListNetworksRequest();
                    ListNetworksResponse response = ListNetworks(request);
                    cloudStackVersion = response.CloudStackVersion;
                }
                return cloudStackVersion;
            }
        }

        /// <summary>
        /// Timeout used for connections and used for writes/reads.
        /// </summary>
        public TimeSpan HttpRequestTimeout
        {
            get;
            private set;
        }

        /// <summary>
        /// Time between polling an async operation to see if it has completed.
        /// </summary>
        public TimeSpan CloudPollRate
        {
            get;
            private set;
        }

        public string SessionKey { get { return this.sessionKey; } }

        public CookieCollection Cookies
        {
            get
            {
                return (cookieContainer == null) ? null : cookieContainer.GetCookies(this.ApiAddress);
            }
         }

        /// <summary>
        /// Get the Impersonation context in use in the current session
        /// </summary>
        public ImpersonationContext ImpersonationContext { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// An alternative authentication mechanism for the Cloudstack API requires the user to login (username/password) rather than
        /// use the apiKey/secureKey combination. If apiKey and ssoKey are present in the client session they will be used in
        /// preference to this mechanism.
        /// </summary>
        /// <param name="userName">CloudStack user name</param>
        /// <param name="password">ClousStack password</param>
        /// <param name="domainName">Optional CloudStack domainName (may be null for root domainName)</param>
        /// <param name="hashPassword">Should an MD5 hash of the password be sent</param>
        public void Login(string userName, string password, string domainName, bool hashPassword)
        {
            this.cookieContainer = new CookieContainer();
            APIRequest request = new APIRequest("login");
            request.Parameters["username"] = userName;
            request.Parameters["password"] = hashPassword ?  Hash(password) : password;
            if (!string.IsNullOrEmpty(domainName)) {
                request.Parameters["domain"] = domainName;
            }
            XDocument response = this.SendRequest(request);
            this.sessionKey = response.Element("loginresponse").Element("sessionkey").Value;
        }

        /// <summary>
        /// An alternative authentication mechanism for the Cloudstack API requires the user to login (username/password) rather than
        /// use the apiKey/secureKey combination. If apiKey and ssoKey are present in the client session they will be used in
        /// preference to this mechanism.
        /// </summary>
        /// <param name="userName">CloudStack user name</param>
        /// <param name="password">ClousStack password</param>
        /// <param name="domainName">Optional CloudStack domain name (may be null for root domain)</param>
        /// <param name="hashPassword">Should an MD5 hash of the password be sent</param>
        public void Login(string userName, SecureString password, string domainName, bool hashPassword) {
            this.Login(userName, SecureStringToString(password), domainName, hashPassword);
        }

        /// <summary>
        /// CloudStack single sign on support, using a name/domain combination and the single sign on key.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="ssoKey">security.singlesignon.key</param>
        /// <param name="domainName">optional domain name (defaults to ROOT domain)</param>
        public void LoginWithSso(string userName, string ssoKey, string domainName) {
            this.cookieContainer = new CookieContainer();
            APIRequest request = new APIRequest("login");
            request.Parameters["username"] = userName;
            request.Parameters["timestamp"] = (DateTime.UtcNow - UnixBaseTime).TotalMilliseconds.ToString("F0");
            if (!string.IsNullOrEmpty(domainName)) {
                request.Parameters["domain"] = domainName;
            }
            XDocument response = this.SendRequest(request, CreateSecureString(ssoKey), null);
            this.sessionKey = response.Element("loginresponse").Element("sessionkey").Value;       
        }

        /// <summary>
        /// Use this ImpersonationContext when creating resources
        /// </summary>
        public Client Impersonate(ImpersonationContext impersonationContext) {
            Client copy = this.MemberwiseClone() as Client;
            copy.ImpersonationContext = impersonationContext;
            return copy;
        }

        /// <summary>
        /// LoginWithSso this account/domainName when creating resources
        /// </summary>
        public Client Impersonate(string account, string domainId) {
            return this.Impersonate(new ImpersonationContext(account, domainId));
        }
        


        public void Logout()
        {
            try
            {
                APIRequest request = new APIRequest("logout");
                this.SendRequest(request);
            }
            finally
            {
                this.sessionKey = null;
                this.cookieContainer = null;
            }
        }

        /// <summary>
        /// Produces a query string with an optional signature from arguments in key/value string form.
        /// </summary>
        /// <param name="arguments">Command in terms of key/value pairs</param>
        /// <param name="ssoKey">Optional secret key if the query is to be signed</param>
        /// <returns>Http query string including the signature.</returns>
        /// <remarks>
        /// Reference:  
        /// http://docs.cloud.com/CloudStack_Documentation/Developer%27s_Guide%3A_CloudStack#Signing_API_Requests
        /// </remarks>
        public static string CreateQuery(IDictionary<string, string> arguments, SecureString secretKey, string sessionKey)
        {
            StringBuilder query = new StringBuilder();
            SortedList<string, string> sortedArgs = new SortedList<string, string>(arguments);

            foreach (string key in sortedArgs.Keys)
            { 
                string nextArg = string.Format(CultureInfo.InvariantCulture, "{0}={1}&", key, UrlEncode(arguments[key]));
                query.Append(nextArg);
            }
            query.Remove(query.Length - 1, 1);

            if (secretKey != null)
            {
                string signBase64 = CalcSignature(query.ToString().ToLowerInvariant(), secretKey);
                string urlParamSignature = UrlEncode(signBase64);
                query.Append(string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "signature", urlParamSignature));
            }
            else if (sessionKey != null)
            {
                query.Append(string.Format(CultureInfo.InvariantCulture, "&{0}={1}", "sessionkey", UrlEncode(sessionKey)));
            }
            return query.ToString();
        }

        /// <summary>
        /// Calculates a HMAC SHA-1 hash of the supplied string.
        /// </summary>
        /// <param name="toSign">String to sign</param>
        /// <param name="ssoKey">Signing private key</param>
        /// <returns>HMAC SHA-1 signature</returns>     
        public static string CalcSignature(string toSign, SecureString secretKey)
        {
            if (secretKey == null)
                throw new ArgumentNullException("secretKey");
            string key = SecureStringToString(secretKey);
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(key);
            HMACSHA1 hasher = new System.Security.Cryptography.HMACSHA1(secretKeyBytes);
            byte[] bytesToSign = Encoding.UTF8.GetBytes(toSign);
            byte[] signatureUTF8 = hasher.ComputeHash(bytesToSign);
            return Convert.ToBase64String(signatureUTF8);
        }

        /// <summary>
        /// Creates a SecureString corresponding to a regular string.
        /// </summary>
        /// <param name="plaintext">String to be made secure.</param>
        /// <returns>SecureString equivalent of the regular string.</returns>
        public static SecureString CreateSecureString(string plaintext)
        {
            if (plaintext == null)
                throw new ArgumentNullException("plaintext");
            SecureString secStr = new SecureString();
            foreach (char c in plaintext)
            {
                secStr.AppendChar(c);
            }

            return secStr;
        }
               
        /// <summary>
        /// Normalize any array properties in the supplied object to replace null values with empty arrays
        /// </summary>
        /// <typeparam name="T">Type of object to be normalized</typeparam>
        /// <param name="obj">object to convert</param>
        /// <returns>converted object</returns>
        public static T NormalizeArrays<T>(T obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            if (properties != null)
            {
                foreach (PropertyInfo property in properties)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsArray)
                    {
                        object propVal = property.GetValue(obj, null);                      
                        if (propVal == null)
                        {
                            ConstructorInfo constructor = propertyType.GetConstructor(new Type[] { typeof(int) });
                            object instance = constructor.Invoke(new object[] { (int)0 });
                            property.SetValue(obj, instance, null);
                        }
                    }  
                }
            }
            return obj;
        }

        /// <summary>
        /// Parses XML response into parameterized type.
        /// </summary>
        /// <typeparam name="T">Type of object to be returned.</typeparam>
        /// <param name="response">XDocument response.</param>
        /// <param name="apiCallName">Name of API call, used for error handling.</param>
        /// <returns>Object whose properties are populated by the XDocument result.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Invocation must explicity specify type")]
        public static T DeserialiseResponse<T>(XContainer response, string apiCallName)
        {
            XmlSerializer dataSerializer = new XmlSerializer(typeof(T));
            try
            {
                using (XmlReader xmlRdr = response.CreateReader())
                {
                    T result = (T)dataSerializer.Deserialize(xmlRdr);
                    APIResponse r = result as APIResponse;
                    if (r != null)
                    {
                        r.XmlResponse = response;
                    }
                    return NormalizeArrays(result);
                }
            }
            catch (Exception e)
            {
                throw new CloudStackException("Error deserializing response", apiCallName, response, e);
            }
        }

        /// <summary>
        /// Invoke API call and parse response XML into parameterised type.
        /// </summary>
        /// <typeparam name="T">Type of object to be returned.</typeparam>
        /// <param name="apiCall">API call that generates an XDocument result.</param>
        /// <param name="apiCallName">Name of API call, used for error handling.</param>
        /// <returns>Object whose properties are populated by the XDocument result.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Invocation must explicity specify type")]
        public static T DeserialiseResponse<T>(Func<XDocument> apiCall, string apiCallName)
        {
            XDocument response = apiCall();
            return DeserialiseResponse<T>(response, apiCallName);
        }

        /// <summary>
        /// Low level API to transmit request to CloudStack API server and return raw XML response.
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Raw XML response from CloudStack.</returns>
        /// <exception cref="CloudStackException">Any errors are thrown as CloudStackException</exception>
        public XDocument SendRequest(APIRequest request)
        {          
            if (!request.Parameters.ContainsKey("apikey") && (this.apiKey != null))
            {
                request.Parameters["apikey"] = this.apiKey;
            }

            if (ImpersonationContext != null)
            {
                if (request.SupportsImpersonation)
                {
                    request.Parameters["account"] = ImpersonationContext.Account;
                    request.Parameters["domainid"] = ImpersonationContext.DomainId; 
                }
            }

            return SendRequest(request, this.secretKey, this.sessionKey);
        }

        /// <summary>
        /// This method will convert the APIRequest into an Http query, either signed by the secret key (if present)
        /// or accompanied by the sessionkey. The query is sent to the ApiAddress and the resulting document returned.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ssoKey"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        private XDocument SendRequest(APIRequest request, SecureString secretKey, string sessionKey) {
            string queryString = CreateQuery(request.Parameters, secretKey, sessionKey);
            Uri fullUri = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}?{1}", this.ApiAddress, queryString));

            HttpWebRequest httpWebRequest = WebRequest.Create(fullUri) as HttpWebRequest;
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.Timeout = (int)this.HttpRequestTimeout.TotalMilliseconds;

            try {
                httpWebRequest.Method = "GET";
                using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse) {
                    using (Stream respStrm = httpWebResponse.GetResponseStream()) {
                        respStrm.ReadTimeout = (int)this.HttpRequestTimeout.TotalMilliseconds;
                        using (StreamReader streamReader = new StreamReader(respStrm, Encoding.UTF8)) {
                            try {
                                return XDocument.Load(streamReader);
                            } catch (System.Xml.XmlException xmlEx) {
                                throw new CloudStackException(
                                    "Error parsing API response",
                                    fullUri.ToString(),
                                    xmlEx.Message,
                                    "Invalid response XML is typical of wrong URL (e.g. does not end with '/api')",
                                    xmlEx);
                            }
                        }
                    }
                }
            } catch (WebException e) {
                throw CreateCloudStackException(e, fullUri);
            }
        }

   
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Implement IDisposable.Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // Disposal has been done. Take object off finalization queue
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        ///  Dispose(bool disposing) executes in two distinct scenarios.  If disposing equals true, the method 
        /// has been called directly or indirectly by a user's code. Managed and unmanaged resources  can be disposed. 
        /// If disposing equals false, the method has been called by the runtime from inside the finalizer and you 
        /// should not reference ther objects. Only unmanaged resources can be disposed. 
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {         
            if (!disposed)
            {
                if (disposing)
                {
                    secretKey.Dispose();
                }

                disposed = true;
            }
        }

        #region Private Methods

        private string Hash(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Url encode a string suitable for sending to CloudStack. Spaces must be encoded as %20 rather than +
        /// </summary>
        private static string UrlEncode(string s)
        {
            return string.IsNullOrEmpty(s) ? s : HttpUtility.UrlEncode(s).Replace("+", "%20");
        }

        /// <summary>
        /// Convert SecureString to string.
        /// </summary>
        /// <param name="secureString">secure string to convert</param>
        /// <returns>string type</returns>
        private static string SecureStringToString(SecureString secureString)
        {
            if (secureString == null)
            {
                throw new ArgumentNullException("secureString");
            }

            IntPtr unmanaged = IntPtr.Zero;
            try
            {
                unmanaged = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanaged);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanaged);
            }
        }

        /// <summary>
        /// Create a CloudStackException from the supplied WebException. If avaiable the response
        /// stream is read and added to the exception.
        /// </summary>
        /// <param name="we">The WebException</param>
        /// <param name="fullUri">URI of the server</param>
        /// <returns>a CloudStackException</returns>
        private static CloudStackException CreateCloudStackException(WebException we, Uri fullUri)
        {
            if (we.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;
                try
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            return new CloudStackException(
                                "ProtocolError on API call",
                                fullUri.ToString(),
                                XDocument.Load(reader),
                                we);
                        }
                    }
                }
                catch
                {
                    return new CloudStackException(
                        "Error on API call (cannot read response stream)",
                        fullUri.ToString(),
                        response.StatusCode.ToString(),
                        response.StatusDescription,
                        we);
                }
            }
            return new CloudStackException(
                "Error on API call",
                fullUri.ToString(),
                we.Status.ToString(),
                we.Message,
                    we);
        }

        #endregion 
    }
}
