using System.Diagnostics;
using System.ServiceModel.Dispatcher;
using Newtonsoft.Json;
using System.ServiceModel.Channels;
using WcfTrials.Helper.Exception;
using System.ServiceModel;
using WcfTrials.Model.Logger;
using WcfTrials.Helper.Logger;

namespace WcfTrials.Helper.Behavior
{
    public class WcfTrialsParameterInspector : IParameterInspector, IErrorHandler
    {
        private readonly string _serviceIdentifier;
        private readonly ILogger _logger;

        public WcfTrialsParameterInspector(string serviceIdentifier)
        {
            _serviceIdentifier = serviceIdentifier;
            _logger = new Logger.Logger();
        }
        public Stopwatch Watch { get; set; }
        public object[] inputs { get; set; }
        public string OperationName { get; set; }
        public string Url { get; set; }
        public RequestIdentifier Identifier { get; set; }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Watch.Stop();
            var message = inputs.Length == 1 ? JsonConvert.SerializeObject(inputs[0]) : JsonConvert.SerializeObject(inputs);
            var elapsedTime = Watch.ElapsedMilliseconds;
            var logMessage = new Log
            {
                Input = message,
                Exception = null,
                Message = "Message from After Calls",
                Operation = OperationName,
                Output = null,
                ResponseTime = elapsedTime,
                Url = _serviceIdentifier,
                Identifier = Identifier.UniqueIdentifier
            };
            _logger.Information(logMessage);
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            Watch = Stopwatch.StartNew();
            this.inputs = inputs;
            OperationName = operationName;
            var serviceInstance = OperationContext.Current.InstanceContext.GetServiceInstance();
            Identifier = (serviceInstance as BaseService).Identifier;
            return null;
        }

        public bool HandleError(System.Exception error)
        {
            return true;
        }

        public void ProvideFault(System.Exception error, MessageVersion version, ref Message fault)
        {
            if (Watch.IsRunning)
                Watch.Stop();
            var wcfTrialsFault = new WcfTrialsFault
            {
                Code = 1,
                Message = error.Message
            };

            LogError(error, Watch.ElapsedMilliseconds);

            var faultException = new FaultException<WcfTrialsFault>(wcfTrialsFault, "Error occurred while invoking the method.");
            MessageFault faultExp = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, faultExp, null);
        }

        private void LogError(System.Exception exception, long elapsedTime)
        {
            var logMessage = new Log
            {
                Exception = exception,
                Input = inputs.Length == 1 ? JsonConvert.SerializeObject(inputs[0]) : JsonConvert.SerializeObject(inputs),
                Message = exception.Message,
                Operation = OperationName,
                ResponseTime = elapsedTime,
                Url = _serviceIdentifier,
                Timestamp = System.DateTime.Now,
                Identifier = Identifier.UniqueIdentifier
            };
            _logger.Error(logMessage);
        }
    }
}