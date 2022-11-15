using System.Runtime.Serialization;

namespace HRC.Service.Results
{
    [DataContract]
    public class BaseResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}