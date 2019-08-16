using System.ServiceModel;
using WcfTrials.Helper.Exception;
using WcfTrials.Model.Contract;

namespace WcfTrials.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        void DoWork(string request);

        [OperationContract]
        [FaultContract(typeof(WcfTrialsFault))]
        void DoWorkInt(int request);

        [OperationContract]
        void DoWorkCustomObject(DoWorkRequest request, DoWorkRequest request2);
    }
}
