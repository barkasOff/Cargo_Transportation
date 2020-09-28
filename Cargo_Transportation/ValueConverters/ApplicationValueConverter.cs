using Cargo_Transportation.Pages;
using Cargo_Transportation.Pages.LogRegPages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Cargo_Transportation.ValueConverters
{
    public class ApplicationValueConverter : BaseValueConverter<ApplicationValueConverter>
    {
        public override object Convert(object value, Type targetType = null,
            object parameter = null, CultureInfo culture = null)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.Register:
                    return new RegisterPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
