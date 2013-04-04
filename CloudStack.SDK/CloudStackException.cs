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
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Exception type thrown by SDK.
    /// </summary>
    [Serializable]
    public class CloudStackException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the CloudStackException class.
        /// </summary>
        public CloudStackException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudStackException class.
        /// </summary>
        /// <param name="context">Description of problem.</param>
        /// <param name="command">Details of command being executed at time of error.</param>
        /// <param name="apiErrorResult">Error details from API.</param>
        public CloudStackException(string context, string command, XContainer apiErrorResult)
            : this(context, command, apiErrorResult, null) 
        {             
        }

        /// <summary>
        /// Initializes a new instance of the CloudStackException class.
        /// </summary>
        /// <param name="context">Description of problem.</param>
        /// <param name="command">Details of command being executed at time of error.</param>
        /// <param name="errorCode">ErrorCode field of APIErrorResult property.</param>
        /// <param name="errorText">ErrorText field of APIErrorResult property.</param>
        public CloudStackException(string context, string command, string errorCode, string errorText)
            : this(context, command, errorCode, errorText, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudStackException class.
        /// </summary>
        /// <param name="context">Description of problem.</param>
        /// <param name="command">Details of command being executed at time of error.</param>
        /// <param name="apiErrorResult">Error details from API.</param>
        /// <param name="innerException">Exception causing problem.</param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Need property to access underlying member variable")]
        public CloudStackException(string context, string command, XContainer apiErrorResult, Exception innerException)
            : base(context, innerException) 
        {
            this.Context = context;
            this.Command = string.IsNullOrEmpty(command) ? string.Empty : command;
            APIErrorResult apiError = new APIErrorResult(apiErrorResult);

            this.APIErrorResult = apiError;
        }

        /// <summary>
        /// Initializes a new instance of the CloudStackException class.
        /// </summary>
        /// <param name="context">Description of problem.</param>
        /// <param name="command">Details of command being executed at time of error.</param>
        /// <param name="errorCode">ErrorCode field of APIErrorResult property.</param>
        /// <param name="errorText">ErrorText field of APIErrorResult property.</param>
        /// <param name="innerException">Exception causing problem.</param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Need property to access underlying member variable")]
        public CloudStackException(string context, string command, string errorCode, string errorText, Exception innerException)
            : base(context, innerException)
        {
            this.Context = context;
            this.Command = command == null ? string.Empty : command;
            this.APIErrorResult = new APIErrorResult()
            {
                ErrorText = errorText,
                ErrorCode = errorCode
            };
        }
        
        /// <summary>
        /// Initializes a new instance of the CloudStackException class. 
        /// </summary>
        /// <param name="info">
        /// Serialized data.
        /// </param>
        /// <param name="context">
        /// Deserialization context.
        /// </param>
        protected CloudStackException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Summary of exception details
        /// </summary>
        public override string Message
        {
            get
            {
                return this.APIErrorResult.ToString() + " Command: " + this.Command + " Context: " + this.Context;
            }
        }

        /// <summary>
        /// Stores fragment of command called.
        /// </summary>
        public string Context 
        {
            get 
            { 
                return (string)this.Data["Context"]; 
            }

            set 
            { 
                this.Data["Context"] = value; 
            } 
        }

        /// <summary>
        /// Stores fragment of command called.
        /// </summary>
        public string Command
        {
            get
            {
                return (string)this.Data["Command"];
            }

            set
            {
                this.Data["Command"] = value;
            }
        }

        /// <summary>
        /// ErrorCode and ErrorText from CloudStack API.
        /// </summary>
        public APIErrorResult APIErrorResult
        {
            get 
            { 
                return (APIErrorResult)this.Data["APIErrorResult"]; 
            }

            set 
            { 
                this.Data["APIErrorResult"] = value; 
            } 
        }
    }
}
