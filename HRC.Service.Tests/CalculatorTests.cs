using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRC.Service.Library;
using System;

namespace HRC.Service.Test
{
    [TestClass]
    public class CalculatorTest
    {
        int[,] validMatrix = new int[5,5];
        int[,] invalidMatrix = new int[,] { };

        public CalculatorTest()
        {
            validMatrix[0, 0] = 4;
            validMatrix[0, 1] = 9;
            validMatrix[0, 2] = 5;
            validMatrix[0, 3] = 2;
            validMatrix[0, 4] = 8;

            validMatrix[1, 0] = 8;
            validMatrix[1, 1] = 4;
            validMatrix[1, 2] = 2;
            validMatrix[1, 3] = 1;
            validMatrix[1, 4] = 3;

            validMatrix[2, 0] = 1;
            validMatrix[2, 1] = 4;
            validMatrix[2, 2] = 1;
            validMatrix[2, 3] = 8;
            validMatrix[2, 4] = 2;

            validMatrix[3, 0] = 7;
            validMatrix[3, 1] = 5;
            validMatrix[3, 2] = 9;
            validMatrix[3, 3] = 7;
            validMatrix[3, 4] = 0;

            validMatrix[4, 0] = 9;
            validMatrix[4, 1] = 3;
            validMatrix[4, 2] = 7;
            validMatrix[4, 3] = 8;
            validMatrix[4, 4] = 8;
        }

        [TestMethod]
        public void ShouldNotCalculateDeterminant()
        {
            // preparation
            var service = new Calculator();
            
            // execute
            var twodarray = invalidMatrix.ToJaggedArray();
            var result = service.CalcDeterminant(twodarray);

            // assert
            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Message));
            Assert.IsTrue(result.Determinant == 0);
        }

        [TestMethod]
        public void ShouldCalculateDeterminant()
        {
            // preparation
            var service = new Calculator();
            
            // execute
            var twodarray = validMatrix.ToJaggedArray();
            var result = service.CalcDeterminant(twodarray);

            // assert
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.Message));
            Assert.AreEqual(result.Determinant, 30033);
        }


        [TestMethod]
        public void ShouldNotFilterAndOrderValues()
        {
            // preparation
            var service = new Calculator();

            // execute
            var twodarray = invalidMatrix.ToJaggedArray();
            var result = service.FilterAndOrderValues(twodarray);

            // assert
            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Message));
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.FilterAndOrderValues));
        }

        [TestMethod]
        public void ShouldFilterAndOrderValues()
        {
            // preparation
            var service = new Calculator();

            // execute
            var twodarray = validMatrix.ToJaggedArray();
            var result = service.FilterAndOrderValues(twodarray);

            // assert
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.Message));
            Assert.AreEqual(result.FilterAndOrderValues, "0,2,4,8");
        }
    }
}
