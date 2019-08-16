using Newtonsoft.Json;
using System.IO;
using WcfTrials.Model.Logger;

namespace WcfTrials.Helper.Logger
{
    public class Logger : ILogger
    {
        private string _filePath = "Logger.txt";

        public Logger()
        {
        }
        public void Error(Log message)
        {
            message.LogType = LogTypeEnum.Error;
            message.Timestamp = System.DateTime.Now;
            WriteLog(message);
        }

        public void Information(Log message)
        {
            message.LogType = LogTypeEnum.Information;
            message.Timestamp = System.DateTime.Now;
            WriteLog(message);
        }

        private void WriteLog(Log message)
        {
            using (var fileStream = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(fileStream))
            {
                var writeObject = JsonConvert.SerializeObject(message);
                writer.WriteLine(writeObject);
            }
        }
    }
}