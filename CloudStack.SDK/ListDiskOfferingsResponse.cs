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
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "listdiskofferingsresponse", Namespace = "", IsNullable = false)]
    public class ListDiskOfferingsResponse : APIResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("diskoffering")]
        public DiskOffering[] DiskOffering { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DiskOffering : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("displaytext")]
        public string DisplayText { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("disksize")]
        public long DiskSize { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("created")]
        public string Created { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("iscustomized")]
        public bool IsCustomized { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("tags")]
        public string Tags { get; set; }
    }
}
