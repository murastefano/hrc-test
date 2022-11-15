using HRC.Service.Library.CalculatorServiceReference;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HRC.Service.Library
{
    // Replace the Guid below with your own guid that
    // you generate using Create GUID from the Tools menu
    [Guid("A33BF1F2-483F-48F9-8A2D-4DA68C53C13B")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class CalculatorServiceClient
    {
        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type type)
        {
            Registry.ClassesRoot.CreateSubKey(GetSubKeyName(type, "Programmable"));
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(GetSubKeyName(type, "InprocServer32"), true);
            key.SetValue("", System.Environment.SystemDirectory + @"\mscoree.dll", RegistryValueKind.String);
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type type)
        {
            Registry.ClassesRoot.DeleteSubKey(GetSubKeyName(type, "Programmable"), false);
        }
        private static string GetSubKeyName(Type type, string subKeyName)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append(@"CLSID\{");
            s.Append(type.GUID.ToString().ToUpper());
            s.Append(@"}\");
            s.Append(subKeyName);
            return s.ToString();
        }

        /// <summary>
        /// receives a matrix (2D array) and returns the determinant.
        /// </summary>
        /// <param name="matrixValues">the matrix integer values matrix</param>
        /// <returns>int</returns>
        public int CalcDeterminant(int[,] matrixValues)
        {
            try
            {
                using (CalculatorClient client = new CalculatorClient())
                {
                    var jaggerMatrix = matrixValues.ToJaggedArray();
                    var result = client.CalcDeterminant(jaggerMatrix);

                    return result.Determinant;
                }
            }
            catch (Exception ex)
            {
                // todo: handle errors, propagate
                return 0;
            }
        }

        /// <summary>
        /// receives a matrix, enumerate the values, discards odds, eliminates
        /// duplicates, sorts them in ascending order, and returns them as a string.
        /// </summary>
        /// <param name="matrixValues">the integer values matrix</param>
        /// <returns>string</returns>
        public string FilterAndOrderValues(int[,] matrixValues)
        {
            try
            {
                using (CalculatorClient client = new CalculatorClient())
                {
                    var jaggerMatrix = matrixValues.ToJaggedArray();
                    var result = client.FilterAndOrderValues(jaggerMatrix);

                    return result.FilterAndOrderValues;
                }
            }
            catch (Exception ex)
            {
                // todo: handle errors, propagate
                return string.Empty;
            }
        }
    }
}
