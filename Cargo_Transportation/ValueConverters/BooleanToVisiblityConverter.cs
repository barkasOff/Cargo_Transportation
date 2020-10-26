using System;
using System.Globalization;
using System.Windows;

namespace Cargo_Transportation.ValueConverters
{
    public class                BooleanToVisiblityConverter : BaseValueConverter<BooleanToVisiblityConverter>
    {
        public override object  Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            else
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }
    }
    public class                BooleanInvertConverter : BaseValueConverter<BooleanInvertConverter>
    {
        public override object  Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            !(bool)value;
    }
}
