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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "listvirtualmachinesresponse", Namespace = "", IsNullable = false)]
    public class ListVirtualMachinesResponse : APIResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("virtualmachine")]
        public VirtualMachine[] VirtualMachine { get; set; }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class VirtualMachine : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("displayname")]
        public string DisplayName { get; set; }
        
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
        [System.Xml.Serialization.XmlElement("created")]
        public string Created { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("state")]
        public string State { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("haenable")]
        public bool HaEnable { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("groupid")]
        public string Groupid { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("group")]
        public string Group { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zoneid")]
        public string ZoneId { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zonename")]
        public string ZoneName { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("hostid")]
        public string HostId { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("hostname")]
        public string HostName { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("templateid")]
        public string TemplateId { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("templatename")]
        public string TemplateName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("templatedisplaytext")]
        public string TemplateDisplayText { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("passwordenabled")]
        public bool PasswordEnabled { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isoid")]
        public string Isoid { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isoname")]
        public string Isoname { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("serviceofferingid")]
        public string Serviceofferingid { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("serviceofferingname")]
        public string Serviceofferingname { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("cpunumber")]
        public int Cpunumber { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("cpuspeed")]
        public int Cpuspeed { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("memory")]
        public int Memory { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("cpuused")]
        public string Cpuused { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkkbsread")]
        public int Networkkbsread { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkkbswrite")]
        public int Networkkbswrite { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("guestosid")]
        public string Guestosid { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("rootdeviceid")]
        public string RootDeviceId { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("rootdevicetype")]
        public string RootDeviceType { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("securitygroup")]
        public SecurityGroup[] SecurityGroup { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("nic")]
        public Nic[] Nic { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("hypervisor")]
        public string Hypervisor { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("instancename")]
        public string Instancename { get; set; }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Nic 
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("id")]
        public string Id { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("networkid")]
        public string NetworkId { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("netmask")]
        public string Netmask { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("gateway")]
        public string Gateway { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("ipaddress")]
        public string IpAddress { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isolationuri")]
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Uri no work with XmlSerializer, lacks parameterless ctor")]
        public string IsolationUri { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("broadcasturi")]
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Uri no work with XmlSerializer, lacks parameterless ctor")]
        public string BroadcastUri { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("traffictype")]
        public string TrafficType { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("type")]
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Need property to access underlying member variable")]
        public string Type { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isdefault")]
        public bool IsDefault { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("macaddress")]
        public string MacAddress { get; set; }
    }
}
