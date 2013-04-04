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
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Solves difficult of parsing CloudStack API call error information that is embedded in a variety of responses.
    /// Difficult arises from error information not be demarcated by a specific tag.  Instead, error information may appear
    /// in a job result or at the top level of a response type.
    /// </summary>
    [Serializable]
    public class APIErrorResult
    {
        /// <summary>
        /// Initializes a new instance of the APIErrorResult class from an XDocument contain XML 
        /// corresponding to API call response.
        /// </summary>
        public APIErrorResult()
        {
            this.ErrorText = this.ErrorCode = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the APIErrorResult class from an XDocument contain XML 
        /// corresponding to API call response.
        /// </summary>
        /// <param name="response">XML body of a failed API call.</param>
        /// <remarks>
        /// &lt;?xml version="1.0" encoding="ISO-8859-1"?&gt;&lt;queryasyncjobresultresponse 
        /// cloud-stack-version="3.0.1.20120402225348"&gt;
        /// Sample response: &lt;errorcode&gt;431&lt;/errorcode&gt;
        /// &lt;errortext&gt;Unable to execute API command queryasyncjobresult due to invalid value. 
        /// Object async_job(uuid: foo) does not exist.&lt;/errortext&gt;
        /// &lt;/queryasyncjobresultresponse&gt;
        /// </remarks>
        public APIErrorResult(XContainer response)
            : this()
        {
            if (response == null)
            {
                return;
            }
            this.ParseErrorCode(response);
            this.ParseErrorText(response);
        }

        /// <summary>
        /// HTTP error code.
        /// </summary>
        public string ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// Description of exact problem.
        /// </summary>
        public string ErrorText
        {
            get;
            set;
        }

        /// <summary>
        /// Create string corresponding to object.
        /// </summary>
        /// <returns>String providing error details held by object.</returns>
        public override string ToString()
        {
            return "ErrorCode:" + this.ErrorCode + " ErrorText: " + this.ErrorText;
        }

        private void ParseErrorCode(XContainer response)
        {
            XElement errCode = response.Descendants("errorcode").FirstOrDefault();
            this.ErrorCode = errCode == null ? string.Empty : errCode.Value;
        }

        private void ParseErrorText(XContainer response)
        {
            XElement errText = response.Descendants("errortext").FirstOrDefault();
            this.ErrorText = errText == null ? string.Empty : errText.Value;
        }
    }
}
