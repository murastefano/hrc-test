using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRC.Desktop
{
    public class MatrixRangeValidator : ValidationRule
    {
        public MatrixRangeValidator()
        {
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int matrixValue = (int)value;
            if (matrixValue > 9 || matrixValue < 0)
            {
                return new ValidationResult(false, "invalid matrix value");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
