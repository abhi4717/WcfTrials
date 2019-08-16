using System;

namespace WcfTrials.Model.Logger
{
    public class RequestIdentifier : IRequestIdentifier
    {
        private readonly Guid _requestIdentifier;
        public RequestIdentifier()
        {
            _requestIdentifier = Guid.NewGuid();
        }
        public Guid UniqueIdentifier => _requestIdentifier;
    }
}