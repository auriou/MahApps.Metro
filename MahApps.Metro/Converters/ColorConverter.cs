using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MahApps.Metro.Converters
{
    public class ColorConverter : IValueConverter
    {
        private static readonly Color ColorDifference = Color.FromArgb(0, 61, 155, 85);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Helper.IsInDesignModeStatic)
                return value;
            if (value != null)
            {
                if (value is SolidColorBrush)
                {
                    var colDiff = parameter is SolidColorBrush ? ((SolidColorBrush)parameter).Color : ColorDifference;
                    var color = ((SolidColorBrush)value).Color;
                    var resColor = color - colDiff;
                    return new SolidColorBrush(resColor);
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