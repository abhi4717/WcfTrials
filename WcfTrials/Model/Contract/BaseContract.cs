using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WcfTrials.Model.Contract
{
    [DataContract]
    public abstract class BaseContract
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}