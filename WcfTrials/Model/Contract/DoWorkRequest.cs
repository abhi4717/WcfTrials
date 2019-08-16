using System.Runtime.Serialization;

namespace WcfTrials.Model.Contract
{
    [DataContract]
    public class DoWorkRequest : BaseContract
    {
        [DataMember]
        public string StringRequest { get; set; }
        [DataMember]
        public int intRequest { get; set; }
    }
}