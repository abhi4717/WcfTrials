using System.Runtime.Serialization;

namespace WcfTrials.Helper.Exception
{
    [DataContract]
    public class WcfTrialsFault
    {
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}