using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
    
    //[ValueConversion(typeof (int), typeof (Visibility))]

    [ValueConversion(typeof (int), typeof (Visibility))]
    public class CountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
                return Visibility.Collapsed;
            var list = value as IList;

            if (list != null)
            {
                if (list.Count> 0)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        
    }
}
