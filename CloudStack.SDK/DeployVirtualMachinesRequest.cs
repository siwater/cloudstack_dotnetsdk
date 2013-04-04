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
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Deploy Virtual Machine Request
    /// </summary>
    public class DeployVirtualMachineRequest : APIRequest
    {
        /// <summary>
        /// Initializes a new instance of the DeployVirtualMachineRequest class. 
        /// </summary>
        public DeployVirtualMachineRequest()
            : base("deployVirtualMachine", true)
        {
        }

        /// <summary>
        /// Get or set the Display name
        /// /// </summary>
        public string DisplayName
        {
            get { return GetParameterValue("displayname"); }
            set { SetParameterValue("displayname", value); }
        }

        /// <summary>
        /// Get or set the ServiceOffering Id
        /// </summary>
        public string ServiceOfferingId
        {
            get { return GetParameterValue("serviceofferingid"); }
            set { SetParameterValue("serviceofferingid", value); }
        }

        /// <summary>
        /// Get or set the Template Id
        /// </summary>
        public string TemplateId
        {
            get { return GetParameterValue("templateid"); }
            set { SetParameterValue("templateid", value); }
        }

        /// <summary>
        /// Get or set the Zone Id
        /// </summary>
        public string ZoneId
        {
            get { return GetParameterValue("zoneid"); }
            set { SetParameterValue("zoneid", value); }
        }

        /// <summary>
        /// Get or set the Start VM flag
        /// </summary>
        public bool StartVm
        {
            get { return bool.Parse(GetParameterValue("startvm")); }
            set { SetParameterValue("startvm", value.ToString().ToLowerInvariant()); }
        }

        /// <summary>
        /// Get the Security Group Ids
        /// </summary>
        public Collection<string> SecurityGroupsIds
        {
            get { return Parse(GetParameterValue("securitygroupids")); }
        }

        /// <summary>
        /// Get the network Ids (use WithNetworkIds to set the value)
        /// </summary>
        public Collection<string> NetworkIds
        {
            get { return Parse(GetParameterValue("networkids")); }
        }

        /// <summary>
        /// Get or set the UserData. Note that the UserData will be automatically Base64 
        /// encoded for transmission to the API server if you use this property.
        /// </summary>
        public string UserData
        {
            get { return Base64Decode(GetParameterValue("userdata")); }
            set { SetParameterValue("userdata", Base64Encode(value)); }
        }

        /// <summary>
        /// Base64 encode the string
        /// </summary>
        public static string Base64Encode(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                return Convert.ToBase64String(bytes);
            }
            return data;
        }

        /// <summary>
        /// Base64 decode the string
        /// </summary>
        public static string Base64Decode(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Set the network Ids
        /// </summary>
        public void WithNetworkIds(params string[] networkIds)
        {
            Update("networkids", networkIds);
        }

        /// <summary>
        /// Set the security group Ids
        /// </summary>
        public void WithSecurityGroupIds(params string[] securityGroupIds)
        {
            Update("securitygroupids", securityGroupIds);
        }

        /// <summary>
        /// Parse a comma separated list into its individual components
        /// </summary>
        /// <param name="list">Comman separated list of values</param>
        /// <returns>individual items</returns>
        private static Collection<string> Parse(string list)
        {
            return new Collection<string>(list.Split(',').ToList());
        }
    }
}
