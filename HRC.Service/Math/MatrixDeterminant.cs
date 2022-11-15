using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRC.Service
{
    public static class MatrixDeterminant
    {
        /// <summary>
        /// this method determines the value of determinant using recursion
        /// </summary>
        /// <param name="input">the matrix values</param>
        /// <param name="zeroOrLower">allows only integer greater then zero</param>
        /// <returns>int</returns>
        public static int Determinant(int[,] input, bool noZeroOrLower)
        {
            int order = int.Parse(System.Math.Round(System.Math.Sqrt(input.Length)).ToString());
            if (order > 2)
            {
                int value = 0;
                for (int j = 0; j < order; j++)
                {
                    int[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j, noZeroOrLower) * Determinant(Temp, noZeroOrLower));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }
        }

        /// <summary>
        ///this method determines the sign of the elements
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static int SignOfElement(int i, int j, bool noZeroOrLower)
        {
            if(noZeroOrLower)
            {
                if (i < 0 || j < 0)
                {
                    throw new Exception("Zero and lower values are not allowed");
                }
            }

            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// this method determines the sub matrix corresponding to a given element
        /// </summary>
        /// <param name="input"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static int[,] CreateSmallerMatrix(int[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Round(System.Math.Sqrt(input.Length)).ToString());
            int[,] output = new int[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
    }
}