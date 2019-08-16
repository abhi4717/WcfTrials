using System;

namespace WcfTrials.Model.Logger
{
    public class Log
    {
        public LogTypeEnum LogType { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public string Url { get; set; }
        public string Operation { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public long ResponseTime { get; set; }
        public Guid Identifier { get; set; }
    }
}