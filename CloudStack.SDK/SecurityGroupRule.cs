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
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Generic security group rule
    /// </summary>
    /// <remarks/>
    [Serializable]
    public class SecurityGroupRule
    {
        /// <remarks/>
        [XmlElement("ruleid")]
        public string RuleId { get; set; }

        /// <remarks/>
        [XmlElement(ElementName = "protocol")]
        public ProtocolType Protocol { get; set; }

        /// <remarks/>
        [XmlElement("cidr")]
        public string CIDR { get; set; }

        /// <remarks/>
        [XmlElement(ElementName = "startport")]
        public int StartPort { get; set; }

        /// <remarks/>
        [XmlElement(ElementName = "endport")]
        public int EndPort { get; set; }

        /// <remarks/>
        [XmlElement(ElementName = "icmpcode")]
        public int ICMPCode { get; set; }

        /// <remarks/>
        [XmlElement(ElementName = "icmptype")]
        public int ICMPType { get; set; }

        /// <summary>
        /// Return string representation of object
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(CultureInfo.InvariantCulture, "CIDR: {0}; protocol: {1}; ", CIDR, Protocol));
           switch (Protocol)
           {
               case ProtocolType.icmp:
                   sb.Append(string.Format(CultureInfo.InvariantCulture, "icmp type {0}; icmp code {1}", ICMPType, ICMPCode));
                   break;
               default:
                   sb.Append(string.Format(CultureInfo.InvariantCulture, "start port {0}; end port {1}", StartPort, EndPort));
                   break;
           }
           return sb.ToString();
        }
    }

    /// <summary>
    /// Security Group ingress rule
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(AnonymousType = true)]
    public class IngressRule : SecurityGroupRule
    {
    }

    /// <summary>
    /// Security Group egress rule
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(AnonymousType = true)]
    public class EgressRule : SecurityGroupRule
    {
    }
}
