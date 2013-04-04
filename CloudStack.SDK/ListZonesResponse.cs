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
    using System.Diagnostics.CodeAnalysis;
    using System.Xml.Serialization;
    
    /// <summary>
    /// Models response for a listZones API call.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "listzonesresponse", IsNullable = false)]
    public class ListZonesResponse : APIResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zone")]
        public Zone[] Zone { get; set; }
    }

    /// <summary>
    /// Description of a specific zone.
    /// </summary>
    [System.Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.Xml.Serialization.XmlType(IncludeInSchema = false)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class Zone : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dns1")]
        public string Dns1 { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dns2")]
        public string Dns2 { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("internaldns1")]
        public string InternalDns1 { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("internaldns2")]
        public string InternalDns2 { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("guestcidraddress")]
        public string GuestCidrAddress { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networktype")]
        public string NetworkType { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("securitygroupsenabled")]
        public bool SecurityGroupsEnabled { get; set; }

        /// <remarks/>guestcidraddress
        [System.Xml.Serialization.XmlElement("allocationstate")]
        public string AllocationState { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zonetoken")]
        public string ZoneToken { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dhcpprovider")]
        public string DhcpProvider { get; set; }
    }
}
