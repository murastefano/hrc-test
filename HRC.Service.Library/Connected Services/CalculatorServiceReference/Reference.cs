﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRC.Service.Library.CalculatorServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseResult", Namespace="http://schemas.datacontract.org/2004/07/HRC.Service.Results")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HRC.Service.Library.CalculatorServiceReference.FilterAndOrderValuesResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HRC.Service.Library.CalculatorServiceReference.CalcDeterminantResult))]
    public partial class BaseResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FilterAndOrderValuesResult", Namespace="http://schemas.datacontract.org/2004/07/HRC.Service.Results")]
    [System.SerializableAttribute()]
    public partial class FilterAndOrderValuesResult : HRC.Service.Library.CalculatorServiceReference.BaseResult {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FilterAndOrderValuesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FilterAndOrderValues {
            get {
                return this.FilterAndOrderValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.FilterAndOrderValuesField, value) != true)) {
                    this.FilterAndOrderValuesField = value;
                    this.RaisePropertyChanged("FilterAndOrderValues");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CalcDeterminantResult", Namespace="http://schemas.datacontract.org/2004/07/HRC.Service")]
    [System.SerializableAttribute()]
    public partial class CalcDeterminantResult : HRC.Service.Library.CalculatorServiceReference.BaseResult {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DeterminantField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Determinant {
            get {
                return this.DeterminantField;
            }
            set {
                if ((this.DeterminantField.Equals(value) != true)) {
                    this.DeterminantField = value;
                    this.RaisePropertyChanged("Determinant");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CalculatorServiceReference.ICalculator")]
    public interface ICalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/CalcDeterminant", ReplyAction="http://tempuri.org/ICalculator/CalcDeterminantResponse")]
        HRC.Service.Library.CalculatorServiceReference.CalcDeterminantResult CalcDeterminant(int[][] matrixValues);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/CalcDeterminant", ReplyAction="http://tempuri.org/ICalculator/CalcDeterminantResponse")]
        System.Threading.Tasks.Task<HRC.Service.Library.CalculatorServiceReference.CalcDeterminantResult> CalcDeterminantAsync(int[][] matrixValues);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/FilterAndOrderValues", ReplyAction="http://tempuri.org/ICalculator/FilterAndOrderValuesResponse")]
        HRC.Service.Library.CalculatorServiceReference.FilterAndOrderValuesResult FilterAndOrderValues(int[][] matrixValues);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/FilterAndOrderValues", ReplyAction="http://tempuri.org/ICalculator/FilterAndOrderValuesResponse")]
        System.Threading.Tasks.Task<HRC.Service.Library.CalculatorServiceReference.FilterAndOrderValuesResult> FilterAndOrderValuesAsync(int[][] matrixValues);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorChannel : HRC.Service.Library.CalculatorServiceReference.ICalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<HRC.Service.Library.CalculatorServiceReference.ICalculator>, HRC.Service.Library.CalculatorServiceReference.ICalculator {
        
        public CalculatorClient() {
        }
        
        public CalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HRC.Service.Library.CalculatorServiceReference.CalcDeterminantResult CalcDeterminant(int[][] matrixValues) {
            return base.Channel.CalcDeterminant(matrixValues);
        }
        
        public System.Threading.Tasks.Task<HRC.Service.Library.CalculatorServiceReference.CalcDeterminantResult> CalcDeterminantAsync(int[][] matrixValues) {
            return base.Channel.CalcDeterminantAsync(matrixValues);
        }
        
        public HRC.Service.Library.CalculatorServiceReference.FilterAndOrderValuesResult FilterAndOrderValues(int[][] matrixValues) {
            return base.Channel.FilterAndOrderValues(matrixValues);
        }
        
        public System.Threading.Tasks.Task<HRC.Service.Library.CalculatorServiceReference.FilterAndOrderValuesResult> FilterAndOrderValuesAsync(int[][] matrixValues) {
            return base.Channel.FilterAndOrderValuesAsync(matrixValues);
        }
    }
}