using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using WcfTrials.Model.Logger;

namespace WcfTrials.Helper.Behavior
{
    public class WcfTrialsInstanceProvider : IInstanceProvider
    {
        private readonly Type _instanceType;
        public RequestIdentifier Identifier { get; private set; }
        public WcfTrialsInstanceProvider(Type instanceType)
        {
            _instanceType = instanceType;
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            Identifier = new RequestIdentifier();
            var instance = Activator.CreateInstance(_instanceType, new object[] { Identifier });
            return instance;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}