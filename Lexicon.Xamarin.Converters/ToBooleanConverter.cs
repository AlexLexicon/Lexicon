using System;
using System.Globalization;

namespace Lexicon.Xamarin.Converters
{
    public class ToBooleanConverter : LexiconConverter
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
        public bool GetResult(object value, bool invert)
        {
            if (value == null)
                return false ^ invert;
            if (value is bool val)
                return val ^ invert;
            string str = value.ToString().ToLower();
            if (bool.TryParse(str, out bool boolResult))
                return boolResult ^ invert;
            if (int.TryParse(str, out int intResult))
                return intResult > 0 ^ invert;
            if (double.TryParse(str, out double doubleResult))
                return doubleResult > 0 ^ invert;
            return true ^ invert;
        }
    }
}
