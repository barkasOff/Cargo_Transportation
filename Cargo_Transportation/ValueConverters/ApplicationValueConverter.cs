using Cargo_Transportation.Enums;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Pages.AdministratorPages;
using Cargo_Transportation.Pages.DispatcherPages;
using Cargo_Transportation.Pages.DriverPages;
using Cargo_Transportation.Pages.LogRegPages;
using Cargo_Transportation.Pages.UserPages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Cargo_Transportation.ValueConverters
{
    public class                ApplicationValueConverter : BaseValueConverter<ApplicationValueConverter>
    {
        public override object  Convert(object value, Type targetType = null,
            object parameter = null, CultureInfo culture = null)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.Register:
                    return new RegisterPage();
                case ApplicationPage.UserPage:
                    return new UserPage();
                case ApplicationPage.DispatcherPage:
                    return new DispatcherPage();
                case ApplicationPage.Driver:
                    return new DriverPage();
                case ApplicationPage.Admin:
                    return new AdminPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
