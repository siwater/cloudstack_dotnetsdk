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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "listtemplatesresponse", Namespace = "", IsNullable = false)]
    public class ListTemplatesResponse : APIResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("template")]
        public Template[] Template { get; set; }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Template : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("displaytext")]
        public string DisplayText { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("ispublic")]
        public bool Ispublic { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("created")]
        public string Created { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isready")]
        public bool Isready { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("passwordenabled")]
        public bool Passwordenabled { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("format")]
        public string Format { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isfeatured")]
        public bool Isfeatured { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("crossZones")]
        public bool CrossZones { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("ostypeid")]
        public string OsTypeId { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("ostypename")]
        public string OsTypeName { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("account")]
        public string Account { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zoneid")]
        public string ZoneId { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("zonename")]
        public string ZoneName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("status")]
        public string Status { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("size")]
        public long Size { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("templatetype")]
        public string Templatetype { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("hypervisor")]
        public string Hypervisor { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("domain")]
        public string Domain { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("domainid")]
        public string Domainid { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("isextractable")]
        public bool Isextractable { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("checksum")]
        public string Checksum { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("sourcetemplateid")]
        public string SourceTemplateId { get; set; }
    }
}
