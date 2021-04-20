using System;
using System.Globalization;

namespace Lexicon.Xamarin.Converters
{
    public class ToStringConverter : LexiconConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                string param = parameter.ToString();
                return GetResult(value, false) + param;
            }
            return GetResult(value, true);
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
        public string GetResult(object value, bool nullable) => !nullable && value == null ? string.Empty : value?.ToString();
    }
}