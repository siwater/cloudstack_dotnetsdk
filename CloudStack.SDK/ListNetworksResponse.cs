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
    using System.Diagnostics.CodeAnalysis;
    using System.Xml.Serialization;

    /// <summary>
    /// Models response for a listVolumes API call.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "listnetworksresponse", Namespace = "", IsNullable = false)]
    public class ListNetworksResponse : APIResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("network")]
        public Network[] Network { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Network : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("displaytext")]
        public string DisplayText { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("broadcastdomaintype")]
        public string BroadcastDomainType { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("traffictype")]
        public string TrafficType { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("gateway")]
        public string Gateway { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("netmask")]
        public string Netmask { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("cidr")]
        public string Cidr { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zoneid")]
        public string ZoneId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zonename")]
        public string ZoneName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkofferingid")]
        public string NetworkOfferingId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkofferingname")]
        public string NetworkOfferingName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkofferingdisplaytext")]
        public string NetworkOfferingDisplayText { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkofferingavailability")]
        public string NetworkOfferingAvailability { get; set; }

        /// <remarks/>fd
        [System.Xml.Serialization.XmlElement("issystem")]
        public bool IsSystem { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("state")]
        public string State { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("related")]
        public string Related { get; set; }

        /// <remarks/>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Matching CLoudStack API names")]
        [System.Xml.Serialization.XmlElement("broadcasturi")]
        public string BroadcastUri { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dns1")]
        public string Dns1 { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("dns2")]
        public string Dns2 { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("type")]
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Matching CLoudStack API names")]
        public string Type { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("vlan")]
        public string Vlan { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("acltype")]
        public string AclType { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("subdomainaccess")]
        public string SubDomainAccess { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("account")]
        public string Account { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("domainid")]
        public string DomainId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("domain")]
        public string Domain { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("service")]
        public Service[] Service { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkdomain")]
        public string NetworkDomain { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("physicalnetworkid")]
        public string PhysicalNetworkId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("restartrequired")]
        public bool RestartRequired { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("specifyipranges")]
        public bool SpecifyIpRanges { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Service
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("name")]
        public string Name { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("provider")]
        public Provider[] Provider { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("capability")]
        public Capability[] Capability { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Provider
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("name")]
        public string Name { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Capability
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("name")]
        public string Name { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("value")]
        public string Value { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("canchooseservicecapability")]
        public bool CanChooseServiceCapability { get; set; }
    }
}

