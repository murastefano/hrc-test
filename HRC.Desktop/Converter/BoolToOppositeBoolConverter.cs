using System;
using System.Windows;
using System.Windows.Data;

namespace HRC.Desktop
{
    public class BoolToOppositeBoolConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool _bool = true;
            if (value != null)
                if ((bool)value)
                    _bool = false;

            return _bool;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
