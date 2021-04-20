using System;
using System.Globalization;
using Xamarin.Forms;

namespace Lexicon.Xamarin.Converters
{
    public abstract class LexiconConverter : IValueConverter
    {
        public const string INVERT = "invert";
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        public virtual bool GetValues(object value, object target, out double valueResult, out double targetResult)
        {
            valueResult = -1;
            targetResult = -1;
            if (target == null)
                return true;
            if (value == null)
                return false;
            bool valueParsed = true;
            bool targetParsed = true;
            if (value is double)
                valueResult = (double)value;
            else
                valueParsed = double.TryParse(value.ToString(), out valueResult);
            if (target is double)
                targetResult = (double)target;
            else
                targetParsed = double.TryParse(target.ToString(), out targetResult);
            return valueParsed && targetParsed;
        }
    }
}
