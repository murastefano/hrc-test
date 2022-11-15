using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HRC.Service.Results
{
    [DataContract]
    public class FilterAndOrderValuesResult: BaseResult
    {
        [DataMember]
        public string FilterAndOrderValues { get; set; }

        public FilterAndOrderValuesResult(
            string filterAndOrderValues,
            bool isSuccess,
            string message)
        {
            FilterAndOrderValues = filterAndOrderValues;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}