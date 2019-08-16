using WcfTrials.Model.Logger;

namespace WcfTrials.Helper
{
    public abstract class BaseService
    {
        protected readonly RequestIdentifier _requestIdentifier;
        public BaseService(RequestIdentifier requestIdentifier)
        {
            _requestIdentifier = requestIdentifier;
        }

        public RequestIdentifier Identifier => _requestIdentifier;
    }
}