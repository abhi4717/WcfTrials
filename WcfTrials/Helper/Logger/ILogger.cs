using WcfTrials.Model.Logger;

namespace WcfTrials.Helper.Logger
{
    public interface ILogger
    {
        void Information(Log message);
        void Error(Log message);
    }
}
