﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace Bysykkel.ClearChannelService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://smartbikeportal.clearchannel.no/public/mobapp/", ConfigurationName="ClearChannelService.ClearChannelSoap")]
    public interface ClearChannelSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://smartbikeportal.clearchannel.no/public/mobapp/getRacks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BegingetRacks(System.AsyncCallback callback, object asyncState);
        
        string EndgetRacks(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://smartbikeportal.clearchannel.no/public/mobapp/getRack", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BegingetRack(int id, System.AsyncCallback callback, object asyncState);
        
        string EndgetRack(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ClearChannelSoapChannel : Bysykkel.ClearChannelService.ClearChannelSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getRacksCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getRacksCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getRackCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getRackCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClearChannelSoapClient : System.ServiceModel.ClientBase<Bysykkel.ClearChannelService.ClearChannelSoap>, Bysykkel.ClearChannelService.ClearChannelSoap {
        
        private BeginOperationDelegate onBegingetRacksDelegate;
        
        private EndOperationDelegate onEndgetRacksDelegate;
        
        private System.Threading.SendOrPostCallback ongetRacksCompletedDelegate;
        
        private BeginOperationDelegate onBegingetRackDelegate;
        
        private EndOperationDelegate onEndgetRackDelegate;
        
        private System.Threading.SendOrPostCallback ongetRackCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ClearChannelSoapClient() {
        }
        
        public ClearChannelSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClearChannelSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClearChannelSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClearChannelSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<getRacksCompletedEventArgs> getRacksCompleted;
        
        public event System.EventHandler<getRackCompletedEventArgs> getRackCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Bysykkel.ClearChannelService.ClearChannelSoap.BegingetRacks(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetRacks(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string Bysykkel.ClearChannelService.ClearChannelSoap.EndgetRacks(System.IAsyncResult result) {
            return base.Channel.EndgetRacks(result);
        }
        
        private System.IAsyncResult OnBegingetRacks(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Bysykkel.ClearChannelService.ClearChannelSoap)(this)).BegingetRacks(callback, asyncState);
        }
        
        private object[] OnEndgetRacks(System.IAsyncResult result) {
            string retVal = ((Bysykkel.ClearChannelService.ClearChannelSoap)(this)).EndgetRacks(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetRacksCompleted(object state) {
            if ((this.getRacksCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getRacksCompleted(this, new getRacksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getRacksAsync() {
            this.getRacksAsync(null);
        }
        
        public void getRacksAsync(object userState) {
            if ((this.onBegingetRacksDelegate == null)) {
                this.onBegingetRacksDelegate = new BeginOperationDelegate(this.OnBegingetRacks);
            }
            if ((this.onEndgetRacksDelegate == null)) {
                this.onEndgetRacksDelegate = new EndOperationDelegate(this.OnEndgetRacks);
            }
            if ((this.ongetRacksCompletedDelegate == null)) {
                this.ongetRacksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetRacksCompleted);
            }
            base.InvokeAsync(this.onBegingetRacksDelegate, null, this.onEndgetRacksDelegate, this.ongetRacksCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Bysykkel.ClearChannelService.ClearChannelSoap.BegingetRack(int id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetRack(id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string Bysykkel.ClearChannelService.ClearChannelSoap.EndgetRack(System.IAsyncResult result) {
            return base.Channel.EndgetRack(result);
        }
        
        private System.IAsyncResult OnBegingetRack(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int id = ((int)(inValues[0]));
            return ((Bysykkel.ClearChannelService.ClearChannelSoap)(this)).BegingetRack(id, callback, asyncState);
        }
        
        private object[] OnEndgetRack(System.IAsyncResult result) {
            string retVal = ((Bysykkel.ClearChannelService.ClearChannelSoap)(this)).EndgetRack(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetRackCompleted(object state) {
            if ((this.getRackCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getRackCompleted(this, new getRackCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getRackAsync(int id) {
            this.getRackAsync(id, null);
        }
        
        public void getRackAsync(int id, object userState) {
            if ((this.onBegingetRackDelegate == null)) {
                this.onBegingetRackDelegate = new BeginOperationDelegate(this.OnBegingetRack);
            }
            if ((this.onEndgetRackDelegate == null)) {
                this.onEndgetRackDelegate = new EndOperationDelegate(this.OnEndgetRack);
            }
            if ((this.ongetRackCompletedDelegate == null)) {
                this.ongetRackCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetRackCompleted);
            }
            base.InvokeAsync(this.onBegingetRackDelegate, new object[] {
                        id}, this.onEndgetRackDelegate, this.ongetRackCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override Bysykkel.ClearChannelService.ClearChannelSoap CreateChannel() {
            return new ClearChannelSoapClientChannel(this);
        }
        
        private class ClearChannelSoapClientChannel : ChannelBase<Bysykkel.ClearChannelService.ClearChannelSoap>, Bysykkel.ClearChannelService.ClearChannelSoap {
            
            public ClearChannelSoapClientChannel(System.ServiceModel.ClientBase<Bysykkel.ClearChannelService.ClearChannelSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BegingetRacks(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("getRacks", _args, callback, asyncState);
                return _result;
            }
            
            public string EndgetRacks(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("getRacks", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegingetRack(int id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = id;
                System.IAsyncResult _result = base.BeginInvoke("getRack", _args, callback, asyncState);
                return _result;
            }
            
            public string EndgetRack(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("getRack", _args, result)));
                return _result;
            }
        }
    }
}
