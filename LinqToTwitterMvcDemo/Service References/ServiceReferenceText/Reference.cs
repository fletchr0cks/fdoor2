﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqToTwitterMvcDemo.ServiceReferenceText {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.WebHost4Life.com/webservices", ConfigurationName="ServiceReferenceText.Service1Soap")]
    public interface Service1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.WebHost4Life.com/webservices/stripHTML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string stripHTML(string strUrl, int linkStyle);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1SoapChannel : LinqToTwitterMvcDemo.ServiceReferenceText.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<LinqToTwitterMvcDemo.ServiceReferenceText.Service1Soap>, LinqToTwitterMvcDemo.ServiceReferenceText.Service1Soap {
        
        public Service1SoapClient() {
        }
        
          
        public string stripHTML(string strUrl, int linkStyle) {
            return base.Channel.stripHTML(strUrl, linkStyle);
        }
    }
}