using System.ServiceModel;
using WcfTrials.Helper;
using WcfTrials.Helper.Behavior;
using WcfTrials.Helper.Exception;
using WcfTrials.Model.Contract;
using WcfTrials.Model.Logger;

namespace WcfTrials.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    [WcfTrialsServiceBehavior(typeof(TestService), "TestService")]
    public class TestService : BaseService, ITestService
    {
        public TestService(RequestIdentifier requestIdentifier) : base(requestIdentifier)
        {
        }

        public void DoWork(string request)
        {
        }

        public void DoWorkCustomObject(DoWorkRequest request, DoWorkRequest request2)
        {
        }

        public void DoWorkInt(int request)
        {
            throw new WcfTrialsException();
        }
    }
}
