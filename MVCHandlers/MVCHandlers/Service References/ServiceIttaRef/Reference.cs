﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCHandlers.ServiceIttaRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Client", Namespace="http://schemas.datacontract.org/2004/07/MyWcfService")]
    [System.SerializableAttribute()]
    public partial class Client : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateNaissanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool MarieField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateNaissance {
            get {
                return this.DateNaissanceField;
            }
            set {
                if ((this.DateNaissanceField.Equals(value) != true)) {
                    this.DateNaissanceField = value;
                    this.RaisePropertyChanged("DateNaissance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Marie {
            get {
                return this.MarieField;
            }
            set {
                if ((this.MarieField.Equals(value) != true)) {
                    this.MarieField = value;
                    this.RaisePropertyChanged("Marie");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom {
            get {
                return this.NomField;
            }
            set {
                if ((object.ReferenceEquals(this.NomField, value) != true)) {
                    this.NomField = value;
                    this.RaisePropertyChanged("Nom");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceIttaRef.IServiceItta")]
    public interface IServiceItta {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceItta/GetData", ReplyAction="http://tempuri.org/IServiceItta/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceItta/GetData", ReplyAction="http://tempuri.org/IServiceItta/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceItta/getPartenaire", ReplyAction="http://tempuri.org/IServiceItta/getPartenaireResponse")]
        MVCHandlers.ServiceIttaRef.Client getPartenaire(MVCHandlers.ServiceIttaRef.Client composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceItta/getPartenaire", ReplyAction="http://tempuri.org/IServiceItta/getPartenaireResponse")]
        System.Threading.Tasks.Task<MVCHandlers.ServiceIttaRef.Client> getPartenaireAsync(MVCHandlers.ServiceIttaRef.Client composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceIttaChannel : MVCHandlers.ServiceIttaRef.IServiceItta, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceIttaClient : System.ServiceModel.ClientBase<MVCHandlers.ServiceIttaRef.IServiceItta>, MVCHandlers.ServiceIttaRef.IServiceItta {
        
        public ServiceIttaClient() {
        }
        
        public ServiceIttaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceIttaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceIttaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceIttaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public MVCHandlers.ServiceIttaRef.Client getPartenaire(MVCHandlers.ServiceIttaRef.Client composite) {
            return base.Channel.getPartenaire(composite);
        }
        
        public System.Threading.Tasks.Task<MVCHandlers.ServiceIttaRef.Client> getPartenaireAsync(MVCHandlers.ServiceIttaRef.Client composite) {
            return base.Channel.getPartenaireAsync(composite);
        }
    }
}