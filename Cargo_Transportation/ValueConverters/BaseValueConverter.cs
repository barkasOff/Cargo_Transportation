using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Cargo_Transportation.ValueConverters
{
    public abstract class       BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        private static T        _converter = null;

        public override object  ProvideValue(IServiceProvider serviceProvider) => _converter ??= new T();

        public abstract object  Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object   ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
