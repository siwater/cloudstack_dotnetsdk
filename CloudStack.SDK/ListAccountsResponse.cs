// <copyright company="Citrix Systems, Inc">
//   Copyright © Citrix Systems, Inc.  All rights reserved.
// </copyright>

namespace Citrix.CloudStack.SDK
{
    using System.Xml.Serialization;
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public  class listaccountsresponse {
        /// <remarks/>
        [System.Xml.Serialization.XmlElement("count")]
        public int Count { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute("cloud-stack-version")]
        public string CloudStackVersion { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("account")]
        public Account[] Account { get; set; }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public class Account : CloudResource
    {        
        /// <remarks/>
        public byte domainid {
            get {
                return this.domainidField;
            }
            set {
                this.domainidField = value;
            }
        }
        
        /// <remarks/>
        public string domain {
            get {
                return this.domainField;
            }
            set {
                this.domainField = value;
            }
        }
        
        /// <remarks/>
        public byte receivedbytes {
            get {
                return this.receivedbytesField;
            }
            set {
                this.receivedbytesField = value;
            }
        }
        
        /// <remarks/>
        public byte sentbytes {
            get {
                return this.sentbytesField;
            }
            set {
                this.sentbytesField = value;
            }
        }
        
        /// <remarks/>
        public string vmlimit {
            get {
                return this.vmlimitField;
            }
            set {
                this.vmlimitField = value;
            }
        }
        
        /// <remarks/>
        public byte vmtotal {
            get {
                return this.vmtotalField;
            }
            set {
                this.vmtotalField = value;
            }
        }
        
        /// <remarks/>
        public string vmavailable {
            get {
                return this.vmavailableField;
            }
            set {
                this.vmavailableField = value;
            }
        }
        
        /// <remarks/>
        public string iplimit {
            get {
                return this.iplimitField;
            }
            set {
                this.iplimitField = value;
            }
        }
        
        /// <remarks/>
        public byte iptotal {
            get {
                return this.iptotalField;
            }
            set {
                this.iptotalField = value;
            }
        }
        
        /// <remarks/>
        public string ipavailable {
            get {
                return this.ipavailableField;
            }
            set {
                this.ipavailableField = value;
            }
        }
        
        /// <remarks/>
        public string volumelimit {
            get {
                return this.volumelimitField;
            }
            set {
                this.volumelimitField = value;
            }
        }
        
        /// <remarks/>
        public byte volumetotal {
            get {
                return this.volumetotalField;
            }
            set {
                this.volumetotalField = value;
            }
        }
        
        /// <remarks/>
        public string volumeavailable {
            get {
                return this.volumeavailableField;
            }
            set {
                this.volumeavailableField = value;
            }
        }
        
        /// <remarks/>
        public string snapshotlimit {
            get {
                return this.snapshotlimitField;
            }
            set {
                this.snapshotlimitField = value;
            }
        }
        
        /// <remarks/>
        public byte snapshottotal {
            get {
                return this.snapshottotalField;
            }
            set {
                this.snapshottotalField = value;
            }
        }
        
        /// <remarks/>
        public string snapshotavailable {
            get {
                return this.snapshotavailableField;
            }
            set {
                this.snapshotavailableField = value;
            }
        }
        
        /// <remarks/>
        public string templatelimit {
            get {
                return this.templatelimitField;
            }
            set {
                this.templatelimitField = value;
            }
        }
        
        /// <remarks/>
        public byte templatetotal {
            get {
                return this.templatetotalField;
            }
            set {
                this.templatetotalField = value;
            }
        }
        
        /// <remarks/>
        public string templateavailable {
            get {
                return this.templateavailableField;
            }
            set {
                this.templateavailableField = value;
            }
        }
        
        /// <remarks/>
        public byte vmstopped {
            get {
                return this.vmstoppedField;
            }
            set {
                this.vmstoppedField = value;
            }
        }
        
        /// <remarks/>
        public byte vmrunning {
            get {
                return this.vmrunningField;
            }
            set {
                this.vmrunningField = value;
            }
        }
        
        /// <remarks/>
        public string state {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("user")]
        public Collection<listaccountsresponseAccountUser> user {
            get {
                return this.userField;
            }
            set {
                this.userField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public  class listaccountsresponseAccountUser {
        
        private byte idField;
        
        private string usernameField;
        
        private string firstnameField;
        
        private string lastnameField;
        
        private string emailField;
        
        private string createdField;
        
        private string stateField;
        
        private string accountField;
        
        private byte accounttypeField;
        
        private byte domainidField;
        
        private string domainField;
        
        private string timezoneField;
        
        private string apikeyField;
        
        private string secretkeyField;
        
        /// <remarks/>
        public byte id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        public string firstname {
            get {
                return this.firstnameField;
            }
            set {
                this.firstnameField = value;
            }
        }
        
        /// <remarks/>
        public string lastname {
            get {
                return this.lastnameField;
            }
            set {
                this.lastnameField = value;
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
        
        /// <remarks/>
        public string state {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string account {
            get {
                return this.accountField;
            }
            set {
                this.accountField = value;
            }
        }
        
        /// <remarks/>
        public byte accounttype {
            get {
                return this.accounttypeField;
            }
            set {
                this.accounttypeField = value;
            }
        }
        
        /// <remarks/>
        public byte domainid {
            get {
                return this.domainidField;
            }
            set {
                this.domainidField = value;
            }
        }
        
        /// <remarks/>
        public string domain {
            get {
                return this.domainField;
            }
            set {
                this.domainField = value;
            }
        }
        
        /// <remarks/>
        public string timezone {
            get {
                return this.timezoneField;
            }
            set {
                this.timezoneField = value;
            }
        }
        
        /// <remarks/>
        public string apikey {
            get {
                return this.apikeyField;
            }
            set {
                this.apikeyField = value;
            }
        }
        
        /// <remarks/>
        public string secretkey {
            get {
                return this.secretkeyField;
            }
            set {
                this.secretkeyField = value;
            }
        }
    }
}
