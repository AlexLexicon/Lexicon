using System;
using System.Globalization;

namespace Lexicon.WPF.Converters
{
    public class IsStringNullOrEmptyConverter : LexiconConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                string param = parameter.ToString();
                if (bool.TryParse(param, out bool invert))
                    return GetResult(value, invert);
                if (param.ToLower() == INVERT)
                    return GetResult(value, true);
            }
            return GetResult(value, false);
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
        public bool GetResult(object value, bool invert) => value == null ? !invert : invert ^ string.IsNullOrEmpty(value.ToString());
    }
}
