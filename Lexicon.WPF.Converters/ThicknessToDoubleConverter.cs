using System;
using System.Globalization;
using System.Windows;

namespace Lexicon.WPF.Converters
{
    public class ThicknessToDoubleConverter : LexiconConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
            {
                double total = thickness.Left + thickness.Top + thickness.Right + thickness.Bottom;
                return total / 4;
            }
            return 0;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;
            bool success = double.TryParse(value.ToString(), out double stroke);
            return success ? new Thickness(stroke) : (object)new Thickness();
        }
    }
}
