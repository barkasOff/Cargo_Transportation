using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.LogReg;
using System.ComponentModel;
using System.Security;

namespace Cargo_Transportation.Pages.LogRegPages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class        LoginPage : BasePage, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                DataContext = new LoginViewModel();
            else
                DataContext = IoC.LoginView;
        }

        public SecureString     SecurePassword => PasswordText.SecurePassword;
    }
}
