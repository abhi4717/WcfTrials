using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfTrials.Helper.Behavior
{
    public class WcfTrialsOperationContractBehaviorAttribute : Attribute, IOperationBehavior
    {
        private string _serviceIdentifier;
        public WcfTrialsOperationContractBehaviorAttribute(string serviceIdentifier)
        {
            _serviceIdentifier = serviceIdentifier;
        }
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new WcfTrialsParameterInspector(_serviceIdentifier));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}