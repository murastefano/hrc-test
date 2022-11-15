using System;
using System.Windows;
using System.Windows.Data;

namespace HRC.Desktop
{
    public class BoolToVisibilityConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility _vis = Visibility.Visible;
            if (value != null)
                if (!(bool)value)
                    _vis = Visibility.Collapsed;

            return _vis;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
