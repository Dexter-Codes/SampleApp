using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Sample.Core.Converters
{
    public class TwoWayConverter : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value * value).ToString();
        }

        protected override double ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue;
            double.TryParse(value, out doubleValue);
            return Math.Sqrt(doubleValue);
        }
    }
    public class StringLengthConverter : MvxValueConverter<string>
    {
        protected override object Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value ?? string.Empty;
            return value.Length;
        }
    }
    public class StringReverseConverter : MvxValueConverter<string>
    {
        protected override object Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value ?? string.Empty;
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    public class VisibilityConverter : MvxValueConverter<bool>
    {
        protected override object Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
            {
                return true;
            }
            else
                return false;
        }
    }
}
