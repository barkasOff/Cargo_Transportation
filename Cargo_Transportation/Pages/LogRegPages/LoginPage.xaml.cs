using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.LogReg;
using System.ComponentModel;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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
        private void            TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;

            if (e.Key == Key.Enter)
            {
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                PasswordText.SelectAll();
            }
        }
        private async void      PasswordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EnterBTN.IsDefault = true;
                await Task.Delay(100);
                EnterBTN.IsDefault = false;
            }
        }
    }
}
