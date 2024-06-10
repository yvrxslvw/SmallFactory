using System;
using System.Globalization;
using System.Windows.Data;

namespace SmallFactoryWPF
{
    public class BooleanToTextConverter : IValueConverter
    {
        public string TrueText { get; set; }
        public string FalseText { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? TrueText : FalseText;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
