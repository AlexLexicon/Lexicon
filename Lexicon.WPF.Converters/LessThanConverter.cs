using System;
using System.Globalization;

namespace Lexicon.WPF.Converters
{
    public class LessThanConverter : LexiconConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => GetResult(value, parameter);
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
        public bool GetResult(object value, object target)
        {
            bool success = GetValues(value, target, out double valueResult, out double targetResult);
            return success && valueResult < targetResult;
        }
    }
}
