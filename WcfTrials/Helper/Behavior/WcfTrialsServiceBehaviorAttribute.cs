using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfTrials.Helper.Behavior
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WcfTrialsServiceBehaviorAttribute : Attribute, IServiceBehavior
    {
        private Type _serviceType;

        private string _serviceIdentifier;
        public WcfTrialsServiceBehaviorAttribute(Type serviceType, string serviceIdentifier)
        {
            _serviceType = serviceType;
            _serviceIdentifier = serviceIdentifier;
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var parameterInspector = new WcfTrialsParameterInspector(_serviceIdentifier);
            var instanceProvider = new WcfTrialsInstanceProvider(_serviceType);
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                channelDispatcher.ErrorHandlers.Add(parameterInspector);
                foreach (var endpoint in channelDispatcher.Endpoints)
                {
                    endpoint.DispatchRuntime.InstanceProvider = instanceProvider;
                    foreach (var operation in endpoint.DispatchRuntime.Operations)
                    {
                        operation.ParameterInspectors.Add(parameterInspector);
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}