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
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Base class for all requests.
    /// </summary>
    public class APIRequest
    {
        /// <summary>
        /// Initializes a new instance of the APIRequest class
        /// </summary>
        /// <param name="command">command name</param>
        /// <param name="supportsImpersonation">indicates whether impersonation is supported</param>
        public APIRequest(string command, bool supportsImpersonation)
        {
            Parameters = new Dictionary<string, string>();
            Parameters.Add("command", command);
            SupportsImpersonation = supportsImpersonation;
        }

        /// <summary>
        /// Initializes a new instance of the APIRequest class
        /// </summary>
        /// <param name="command">command name</param>
        public APIRequest(string command)
            : this(command, false)
        {
        }

        /// <summary>
        /// Request parameters.
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get;
            private set;
        }

        /// <summary>
        /// Convenience property to return the API command.
        /// </summary>
        public string Command
        {
            get { return Parameters["command"]; }
        }

        /// <summary>
        /// Indicates whether the request supports impersonation. If this is true an administrative
        /// user can impersonate another user (account) when creating resources
        /// </summary>
        public bool SupportsImpersonation { get; private set; }

        /// <summary>
        /// XML serialisation.
        /// </summary>
        /// <returns>XML version of the object's state.</returns>
        public string ToXML()
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
            using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                xmlSerializer.Serialize(sw, this);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert to string for debug/logging.
        /// </summary>
        /// <returns>XML version of the object's state.</returns>
        public override string ToString()
        {
            return this.ToXML();
        }

        /// <summary>
        /// Get the named parameter value
        /// </summary>
        /// <param name="key">name of the parameter</param>
        /// <returns>the parameter value or null if the parameter does not exist</returns>
        public string GetParameterValue(string key)
        {
            if ((Parameters != null) && Parameters.ContainsKey(key))
            {
                return Parameters[key];
            }
            return null;
        }

        /// <summary>
        /// Set the named parameter value. If the value is null the named parameter will 
        /// be removed from the collection.
        /// </summary>
        /// <param name="key">name of the parameter</param>
        /// <param name="value">value of the parameter</param>
        public void SetParameterValue(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Parameters[key] = value;
            }
            else if (Parameters.ContainsKey(key))
            {
                Parameters.Remove(key);
            }
        }

        /// <summary>
        /// Get the named parameter value
        /// </summary>
        /// <param name="key">name of the parameter</param>
        /// <returns>the parameter value or null if the parameter does not exist</returns>
        public int GetIntParameterValue(string key)
        {
            if ((Parameters != null) && Parameters.ContainsKey(key))
            {
                return int.Parse(Parameters[key], CultureInfo.InvariantCulture);
            }
            return 0;
        }

        /// <summary>
        /// Set the named parameter value. If the value is null the named parameter will 
        /// be removed from the collection.
        /// </summary>
        /// <param name="key">name of the parameter</param>
        /// <param name="value">value of the parameter</param>
        public void SetParameterValue(string key, int value)
        {
            SetParameterValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Update a named parameter that is formatted as comma separated list
        /// </summary>
        /// <param name="name">named of the parameter</param>
        /// <param name="values">collection of values to add to the collection</param>
        protected void Update(string name, params string[] values)
        {
            StringBuilder sb = new StringBuilder();
            if (values != null)
            {    
                foreach (string val in values)
                {
                    if (val != null)
                    {
                        sb.Append(val + ",");
                    }
                }
                if (sb.Length > 1)
                {
                    sb.Remove(sb.Length - 1, 1);
                }          
            }
            SetParameterValue(name, sb.ToString());
        }
    }
}
