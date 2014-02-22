using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace MahApps.Metro.Converters
{
    public class HighlightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var value = System.Convert.ToString(values[0]);
            var terms = System.Convert.ToString(values[1]);
            var param = System.Convert.ToString(parameter);

            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(terms))
            {
                if (value.ToLower().Contains(terms.ToLower()))
                {
                    var findIndex = value.ToLower().IndexOf(terms.ToLower(), System.StringComparison.Ordinal);
                    switch (param)
                    {
                        case "Start":
                            return value.Substring(0, findIndex);
                        case "Find":
                            return value.Substring(findIndex, terms.Length);
                        case "End":
                            return value.Substring(findIndex + terms.Length);
                    }
                }
            }
            if (param == "Start")
            {
                return value;
            }
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class HighlightConverterV1 : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 4 || !(values[0] != null) || !(values[1] is string) || !(values[2] is TextBlock) ||
                !(values[3] is Style))
                return values[0].ToString();
            //return values[0];
            var value = values[0].ToString();
            var terms = (string)values[1];
            var textBox = values[2] as TextBlock;
            var style = values[3] as Style;
            //System.Diagnostics.Debug.WriteLine(value + "  "  +  terms);
            try
            {
                if (String.IsNullOrWhiteSpace(terms))
                    return value;

                textBox.Inlines.Clear();

                if (value.ToLower().Contains(terms.ToLower()))
                {
                    textBox.Text = "";
                    var indexOfHighlightString = value.ToLower().IndexOf(terms.ToLower());
                    textBox.Inlines.Add(value.Substring(0, indexOfHighlightString));
                    textBox.Inlines.Add(new Run()
                    {
                        Text = value.Substring(indexOfHighlightString, terms.Length),
                        Style = style
                        //Foreground = Brushes.Red,
                        //FontWeight = FontWeights.Bold,

                    });
                    textBox.Inlines.Add(value.Substring(indexOfHighlightString + terms.Length));
                    textBox.Inlines.Add(new Run()
                    {
                        Text = " OK",
                        Foreground = Brushes.Red,
                        FontWeight = FontWeights.Bold,

                    });
                    //textBox.UpdateLayout();
                    //return textBox;
                }
                else
                {
                    textBox.Text = value;
                }

                //return value;
            }
            catch (Exception ex)
            {


            }
            return value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
            //throw new NotSupportedException();
        }
    }
   
}
