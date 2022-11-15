using HRC.Service.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HRC.Service
{
    [ServiceContract]
    public interface ICalculator
    {

        [OperationContract]
        CalcDeterminantResult CalcDeterminant(int[][] matrixValues);

        [OperationContract]
        FilterAndOrderValuesResult FilterAndOrderValues(int[][] matrixValues);

    }
}
