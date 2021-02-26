using System;
using System.Drawing;
using System.Globalization;
using MvvmCross.Plugin.Color;

namespace Sample.Core.Converters
{
    public class StatusToColorValueConverter: MvxColorValueConverter<string>
    {

        protected override Color Convert(string value, object parameter, CultureInfo culture)
        {
            var status = value;
            if(status.Equals("Complete"))
            {
                return Color.FromArgb(119, 167, 15);
            }
            else
            {
                return Color.FromArgb(255, 155, 0);
            }
        }
    }
}
