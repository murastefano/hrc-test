using HRC.Service.Results;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HRC.Service
{
    [DataContract]
    public class CalcDeterminantResult: BaseResult
    {
        [DataMember]
        public int Determinant { get; set; }

        public CalcDeterminantResult(
            int determinant,
            bool isSuccess,
            string message)
        {
            Determinant = determinant;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}