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
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Authorize Security Group Ingress Request
    /// </summary>
    public class AuthorizeSecurityGroupIngressRequest : APIRequest
    {
        /// <summary>
        /// Initializes a new instance of the AuthorizeSecurityGroupIngressRequest class. 
        /// </summary>
        public AuthorizeSecurityGroupIngressRequest() : base("createSecurityGroup", true)
        {
        }

        /// <summary>
        /// Get or set the Name of the Security Group. Mutually exclusive with SecurityGroupId parameter
        /// </summary>
        public string SecurityGroupName
        {
            get { return GetParameterValue("securitygroupname"); }
            set { SetParameterValue("securitygroupname", value); }
        }

        /// <summary>
        /// Get or set the Id of the Security Group. Mutually exclusive with SecurityGroupName parameter
        /// </summary>
        public int SecurityGroupId
        {
            get { return GetIntParameterValue("securitygroupid"); }
            set { SetParameterValue("securitygroupid", value); }
        }

        /// <summary>
        /// Get or set the CIDR list
        /// </summary>
        public string CidrList
        {
            get { return GetParameterValue("cidrlist"); }
            set { SetParameterValue("cidrlist", value); }
        }

        /// <summary>
        /// Get or set the start port for the rule
        /// </summary>
        public ProtocolType Protocol
        {
            get { return (ProtocolType) Enum.Parse(typeof(ProtocolType), GetParameterValue("protocol"), true); }
            set { SetParameterValue("protocol", value.ToString()); }
        }

        /// <summary>
        /// Get or set the start port for the rule
        /// </summary>
        public int StartPort
        {
            get { return GetIntParameterValue("startport"); }
            set { SetParameterValue("startport", value); }
        }

        /// <summary>
        /// Get or set the end port for the rule
        /// </summary>
        public int EndPort
        {
            get { return GetIntParameterValue("endport"); }
            set { SetParameterValue("endport", value); }
        }

        /// <summary>
        /// Get or set the ICMP code for the rule
        /// </summary>
        public int ICMPCode
        {
            get { return GetIntParameterValue("icmpcode"); }
            set { SetParameterValue("icmpcode", value); }
        }

        /// <summary>
        /// Get or set the ICMP type for the rule
        /// </summary>
        public int ICMPType
        {
            get { return GetIntParameterValue("icmptype"); }
            set { SetParameterValue("icmptype", value); }
        }
    }
}
