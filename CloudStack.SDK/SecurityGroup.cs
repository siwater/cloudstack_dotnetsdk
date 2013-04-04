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
    [XmlTypeAttribute(AnonymousType = true)]
    public class SecurityGroup : CloudResource
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("description")]
        public string Description { get; set; }

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
        [System.Xml.Serialization.XmlElement("ingressrule")]
        public IngressRule[] IngressRule { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("egressrule")]
        public EgressRule[] EgressRule { get; set; }
    }

    /// <summary>
    /// Security Group as a response from add security group rule commands 
    /// (override to change the deserialization attributes)
    /// </summary>
    [XmlRoot(ElementName = "securitygroup", Namespace = "", IsNullable = false)]
    public class SecurityGroupResponse : SecurityGroup
    {
    }
}
