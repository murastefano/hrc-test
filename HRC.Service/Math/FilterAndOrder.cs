using System;
using System.IO.Compression;
using System.Linq;
using System.Web.Services.Description;

namespace HRC.Service
{
    public static class FilterAndOrder
    {
        /// <summary>
        /// receives a matrix, enumerate the values, discards odds, eliminates
        /// duplicates, sorts them in ascending order, and returns them as a string
        /// </summary>
        /// <param name="input">the matrix values</param>
        /// <returns>string</returns>
        public static string Sort(int[,] input)
        {
            int[] flattered = To1DArraySorted(input);
            int[] noduplicate = flattered.Distinct().ToArray();
            int[] even = RemoveOdd(noduplicate);
            return string.Join(",", even);
        }

        /// <summary>
        /// remove odd from array, only even
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] RemoveOdd(int[] array)
        {
            int m = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    array[m] = array[i];
                    ++m;
                }
            }
            int[] temp = new int[m];
            for (int i = 0; i < m; i++)
                temp[i] = array[i];

            array = temp;
            return array;
        }

        /// <summary>
        /// Flatter 2D rectangular array to 1D 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static int[] To1DArraySorted(int[,] input)
        {
            // Step 1: get total size of 2D array, and allocate 1D array.
            int size = input.Length;
            int[] result = new int[size];

            // Step 2: copy 2D array elements into a 1D array.
            int write = 0;
            for (int i = 0; i <= input.GetUpperBound(0); i++)
            {
                for (int z = 0; z <= input.GetUpperBound(1); z++)
                {
                    result[write++] = input[i, z];
                }
            }
            // Step 3: return the new array.
            Array.Sort(result);
            return result;
        }
    }
}