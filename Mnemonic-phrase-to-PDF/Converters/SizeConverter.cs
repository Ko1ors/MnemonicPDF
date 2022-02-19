using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mnemonic_phrase_to_PDF.Converters
{
    [ValueConversion(typeof(string), typeof(double))]
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double size = (double)new LengthConverter().ConvertFrom(value.ToString());
            return size;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
