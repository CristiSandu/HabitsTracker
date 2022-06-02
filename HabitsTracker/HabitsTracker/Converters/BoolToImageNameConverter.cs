using System;
using System.Globalization;
using Xamarin.Forms;

namespace HabitsTracker.Converters
{
    public class BoolToImageNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "ho.png" : "hf.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
