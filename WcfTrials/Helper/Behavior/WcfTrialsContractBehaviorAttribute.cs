using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfTrials.Helper.Behavior
{
    public class WcfTrialsContractBehaviorAttribute : Attribute, IContractBehavior
    {
        private Type _serviceType;
        private string _serviceIdentifier;
        WcfTrialsContractBehaviorAttribute(Type serviceType, string serviceIdentifier)
        {
            _serviceType = serviceType;
            _serviceIdentifier = serviceIdentifier;
        }
        #region Contract Behavior
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            var parameterInspector = new WcfTrialsParameterInspector(_serviceIdentifier);
            dispatchRuntime.ChannelDispatcher.ErrorHandlers.Add( parameterInspector);
            dispatchRuntime.InstanceProvider = new WcfTrialsInstanceProvider(_serviceType);
            foreach (var operation in dispatchRuntime.Operations)
            {
                operation.ParameterInspectors.Add(parameterInspector);
            }
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
        #endregion
    }

    
}