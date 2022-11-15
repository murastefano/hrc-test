using HRC.Service.Library;
using HRC.Service.Results;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;

namespace HRC.Service
{
    public class Calculator : ICalculator
    {
        /// <summary>
        /// receives a matrix (2D array) and returns the determinant.
        /// </summary>
        /// <param name="matrixValues">the integer values matrix</param>
        /// <returns>CalcDeterminantResult</returns>
        public CalcDeterminantResult CalcDeterminant(int[][] matrixValues)
        {
            try
            {
                if (matrixValues == null || matrixValues.Length == 0)
                {
                    throw new ArgumentNullException(nameof(matrixValues), "Values matrix lenght must be greater the 0 ");
                }

                var twodarray = matrixValues.To2D();
                var determinant = MatrixDeterminant.Determinant(twodarray, true);

                return new CalcDeterminantResult(
                    determinant,
                    true,
                    string.Empty);
            }
            catch (Exception ex)
            {
                // TODO: ADD LOGGER
                return new CalcDeterminantResult(
                                    0,
                                    false,
                                    ex.Message);
            }
        }

        /// <summary>
        /// receives a matrix, enumerate the values, discards odds, eliminates
        /// duplicates, sorts them in ascending order, and returns them as a string.
        /// </summary>
        /// <param name="matrixValues">the integer values matrix</param>
        /// <returns>FilterAndOrderValuesResult</returns>
        public FilterAndOrderValuesResult FilterAndOrderValues(int[][] matrixValues)
        {
            try
            {
                if (matrixValues == null || matrixValues.Length == 0)
                {
                    throw new ArgumentNullException(nameof(matrixValues));
                }

                var twodarray = matrixValues.To2D();
                var filteredValues = FilterAndOrder.Sort(twodarray);

                return new FilterAndOrderValuesResult(
                    filteredValues,
                    true,
                    string.Empty);
            }
            catch (Exception ex)
            {

                // TODO: ADD LOGGER
                return new FilterAndOrderValuesResult(
                                    string.Empty,
                                    false,
                                    ex.Message);
            }
            
        }
    }
}
