﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17379
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMisSharp.CCTWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WebServiceInfo", Namespace="http://www.ChinaCloudTech.com/")]
    [System.SerializableAttribute()]
    public partial class WebServiceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string inameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string incontentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string createdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string createmanField;
        
        private int hitsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string iname {
            get {
                return this.inameField;
            }
            set {
                if ((object.ReferenceEquals(this.inameField, value) != true)) {
                    this.inameField = value;
                    this.RaisePropertyChanged("iname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string incontent {
            get {
                return this.incontentField;
            }
            set {
                if ((object.ReferenceEquals(this.incontentField, value) != true)) {
                    this.incontentField = value;
                    this.RaisePropertyChanged("incontent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string createdate {
            get {
                return this.createdateField;
            }
            set {
                if ((object.ReferenceEquals(this.createdateField, value) != true)) {
                    this.createdateField = value;
                    this.RaisePropertyChanged("createdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string createman {
            get {
                return this.createmanField;
            }
            set {
                if ((object.ReferenceEquals(this.createmanField, value) != true)) {
                    this.createmanField = value;
                    this.RaisePropertyChanged("createman");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public int hits {
            get {
                return this.hitsField;
            }
            set {
                if ((this.hitsField.Equals(value) != true)) {
                    this.hitsField = value;
                    this.RaisePropertyChanged("hits");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.ChinaCloudTech.com/", ConfigurationName="CCTWS.ChinaCloudTechWSSoap")]
    public interface ChinaCloudTechWSSoap {
        
        // CODEGEN: 命名空间 http://www.ChinaCloudTech.com/ 的元素名称 type 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ChinaCloudTech.com/GetWSInfo", ReplyAction="*")]
        CCTWS.GetWSInfoResponse GetWSInfo(CCTWS.GetWSInfoRequest request);
        
        // CODEGEN: 命名空间 http://www.ChinaCloudTech.com/ 的元素名称 MACID 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ChinaCloudTech.com/SoftUsingStat", ReplyAction="*")]
        CCTWS.SoftUsingStatResponse SoftUsingStat(CCTWS.SoftUsingStatRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWSInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWSInfo", Namespace="http://www.ChinaCloudTech.com/", Order=0)]
        public CCTWS.GetWSInfoRequestBody Body;
        
        public GetWSInfoRequest() {
        }
        
        public GetWSInfoRequest(CCTWS.GetWSInfoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ChinaCloudTech.com/")]
    public partial class GetWSInfoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string type;
        
        public GetWSInfoRequestBody() {
        }
        
        public GetWSInfoRequestBody(string type) {
            this.type = type;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWSInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWSInfoResponse", Namespace="http://www.ChinaCloudTech.com/", Order=0)]
        public CCTWS.GetWSInfoResponseBody Body;
        
        public GetWSInfoResponse() {
        }
        
        public GetWSInfoResponse(CCTWS.GetWSInfoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ChinaCloudTech.com/")]
    public partial class GetWSInfoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public CCTWS.WebServiceInfo[] GetWSInfoResult;
        
        public GetWSInfoResponseBody() {
        }
        
        public GetWSInfoResponseBody(CCTWS.WebServiceInfo[] GetWSInfoResult) {
            this.GetWSInfoResult = GetWSInfoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SoftUsingStatRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SoftUsingStat", Namespace="http://www.ChinaCloudTech.com/", Order=0)]
        public CCTWS.SoftUsingStatRequestBody Body;
        
        public SoftUsingStatRequest() {
        }
        
        public SoftUsingStatRequest(CCTWS.SoftUsingStatRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ChinaCloudTech.com/")]
    public partial class SoftUsingStatRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MACID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Remark;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string IP;
        
        public SoftUsingStatRequestBody() {
        }
        
        public SoftUsingStatRequestBody(string MACID, string Remark, string IP) {
            this.MACID = MACID;
            this.Remark = Remark;
            this.IP = IP;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SoftUsingStatResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SoftUsingStatResponse", Namespace="http://www.ChinaCloudTech.com/", Order=0)]
        public CCTWS.SoftUsingStatResponseBody Body;
        
        public SoftUsingStatResponse() {
        }
        
        public SoftUsingStatResponse(CCTWS.SoftUsingStatResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SoftUsingStatResponseBody {
        
        public SoftUsingStatResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ChinaCloudTechWSSoapChannel : CCTWS.ChinaCloudTechWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChinaCloudTechWSSoapClient : System.ServiceModel.ClientBase<CCTWS.ChinaCloudTechWSSoap>, CCTWS.ChinaCloudTechWSSoap {
        
        public ChinaCloudTechWSSoapClient() {
        }
        
        public ChinaCloudTechWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChinaCloudTechWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChinaCloudTechWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChinaCloudTechWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CCTWS.GetWSInfoResponse CCTWS.ChinaCloudTechWSSoap.GetWSInfo(CCTWS.GetWSInfoRequest request) {
            return base.Channel.GetWSInfo(request);
        }
        
        public CCTWS.WebServiceInfo[] GetWSInfo(string type) {
            CCTWS.GetWSInfoRequest inValue = new CCTWS.GetWSInfoRequest();
            inValue.Body = new CCTWS.GetWSInfoRequestBody();
            inValue.Body.type = type;
            CCTWS.GetWSInfoResponse retVal = ((CCTWS.ChinaCloudTechWSSoap)(this)).GetWSInfo(inValue);
            return retVal.Body.GetWSInfoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CCTWS.SoftUsingStatResponse CCTWS.ChinaCloudTechWSSoap.SoftUsingStat(CCTWS.SoftUsingStatRequest request) {
            return base.Channel.SoftUsingStat(request);
        }
        
        public void SoftUsingStat(string MACID, string Remark, string IP) {
            CCTWS.SoftUsingStatRequest inValue = new CCTWS.SoftUsingStatRequest();
            inValue.Body = new CCTWS.SoftUsingStatRequestBody();
            inValue.Body.MACID = MACID;
            inValue.Body.Remark = Remark;
            inValue.Body.IP = IP;
            CCTWS.SoftUsingStatResponse retVal = ((CCTWS.ChinaCloudTechWSSoap)(this)).SoftUsingStat(inValue);
        }
    }
}