using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Pages;
using Cargo_Transportation.Pages.LogRegPages;
using Cargo_Transportation.Pages.UserPages;
using System.Diagnostics;

namespace Cargo_Transportation.ValueConverters
{
    public static class ApplicationPageHelpers
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.Register:
                    return new RegisterPage();
                case ApplicationPage.UserPage:
                    return new UserPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            if (page is LoginPage)
                return ApplicationPage.Login;
            else if (page is RegisterPage)
                return ApplicationPage.Register;
            else if (page is UserPage)
                return ApplicationPage.UserPage;
            else
            {
                Debugger.Break();
                return default(ApplicationPage);
            }
        }
    }
}
