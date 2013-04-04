// <copyright company="Citrix Systems, Inc">
//   Copyright © Citrix Systems, Inc.  All rights reserved.
// </copyright>

namespace Citrix.CloudStack.SDK
{
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public  class listasyncjobsresponse {
        /// <remarks/>
        public int Count { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("asyncjobs")]
        public Collection<AsyncJobs> AsyncJobs { get; set; }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("cloud-stack-version")]
        public string cloudstackversion { get; set; }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public class AsyncJobs
    {
        /// <remarks/>
        public string jobid { get; set; }
        
        /// <remarks/>
        public string accountid { get; set; }
        
        /// <remarks/>
        public string userid { get; set; }
        
        /// <remarks/>
        public string cmd { get; set; }
        
        /// <remarks/>
        public int jobstatus { get; set; }
        
        /// <remarks/>
        public int jobprocstatus { get; set; }
        
        /// <remarks/>
        public int jobresultcode { get; set; }
        
        /// <remarks/>
        public listasyncjobsresponseAsyncjobsJobresult jobresult { get; set; }
        
        /// <remarks/>
        public string created { get; set; }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public class listasyncjobsresponseAsyncjobsJobresult {
        
        /// <remarks/>
        public int errorcode { get; set; }
        
        /// <remarks/>
        public string errortext { get; set; }
    }
}
