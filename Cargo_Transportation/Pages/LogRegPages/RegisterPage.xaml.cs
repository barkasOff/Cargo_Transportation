using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.LogReg;
using System.Security;

namespace Cargo_Transportation.Pages.LogRegPages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class        RegisterPage : BasePage, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }

        public SecureString     SecurePassword => PasswordText.SecurePassword;
    }
}
