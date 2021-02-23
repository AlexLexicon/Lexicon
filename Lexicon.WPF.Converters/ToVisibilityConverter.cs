using System;
using System.Globalization;
using System.Windows;

namespace Lexicon.WPF.Converters
{
    public class ToVisibilityConverter : LexiconConverter
    {
        public const string VISIBLE = "visible";
        public const string COLLAPSED = "collapsed";
        public const string HIDDEN = "hidden";
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
        public Visibility GetResult(object value, bool invert)
        {
            if (value == null)
                return GetVisibility(invert);
            if (value is bool val)
                return GetVisibility(val ^ invert);
            string str = value.ToString().ToLower();
            if (bool.TryParse(str, out bool boolResult))
                return GetVisibility(boolResult ^ invert);
            if (int.TryParse(str, out int intResult))
                return GetVisibility(intResult > 0 ^ invert);
            if (double.TryParse(str, out double doubleResult))
                return GetVisibility(doubleResult > 0 ^ invert);
            if (str == VISIBLE)
                return GetVisibility(true ^ invert);
            else if (str == COLLAPSED)
                return GetVisibility(false ^ invert);
            else if (str == HIDDEN)
                return invert ? Visibility.Visible : Visibility.Hidden;
            return GetVisibility((value != null) ^ invert);
        }
        public Visibility GetVisibility(bool value) => value ? Visibility.Visible : Visibility.Collapsed;
    }
}