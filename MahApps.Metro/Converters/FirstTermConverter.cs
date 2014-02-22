using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class FirstTermConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string && parameter is string)
            {
                var val = value as string;
                if (!string.IsNullOrEmpty(val))
                {
                    var par = parameter as string;
                    if (val.ToLower().Contains(par.ToLower()))
                    {
                        var indexOfHighlightString = val.ToLower().IndexOf(par.ToLower(), System.StringComparison.Ordinal);
                        return val.Substring(0, indexOfHighlightString);
                    }
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}