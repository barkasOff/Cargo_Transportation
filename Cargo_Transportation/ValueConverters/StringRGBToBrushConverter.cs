using System;
using System.Globalization;
using System.Windows.Media;

namespace Cargo_Transportation.ValueConverters
{
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
    }
}
