using System;

namespace WcfTrials.Model.Logger
{
    public interface IRequestIdentifier
    {
        Guid UniqueIdentifier { get; }
    }
}
