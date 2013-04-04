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
    /// Models response for a listVolumes API call.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "listvolumesresponse", Namespace = "", IsNullable = false)]
    public class ListVolumesResponse : APIResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("volume")]
        public Volume[] Volume { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Volume : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zoneid")]
        public string ZoneId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zonename")]
        public string ZoneName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("type")]
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Need property to access underlying member variable")]
        public string Type { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("deviceid")]
        public string DeviceId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("virtualmachineid")]
        public string VirtualMachineId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("vmname")]
        public string VmName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("vmdisplayname")]
        public string VmDisplayname { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("vmstate")]
        public string VmState { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("size")]
        public long Size { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("created")]
        public string Created { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("state")]
        public string State { get; set; }

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
        [System.Xml.Serialization.XmlElement("storagetype")]
        public string StorageType { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("hypervisor")]
        public string Hypervisor { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("diskofferingid")]
        public string DiskOfferingId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("diskofferingname")]
        public string DiskOfferingName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("diskofferingdisplaytext")]
        public string DiskOfferingDisplayText { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("storage")]
        public string Storage { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("attached")]
        public string Attached { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("destroyed")]
        public bool Destroyed { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("serviceofferingid")]
        public string ServiceOfferingId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("serviceofferingname")]
        public string ServiceOfferingName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("serviceofferingdisplaytext")]
        public string ServiceOfferingDisplayText { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isextractable")]
        public bool IsExtractable { get; set; }
    }
}
