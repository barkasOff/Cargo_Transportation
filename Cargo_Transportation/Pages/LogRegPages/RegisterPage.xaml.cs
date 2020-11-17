using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.LogReg;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void            LoginTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var tb = sender as TextBox;

            if (e.Key == Key.Enter)
            {
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                EmailTB.SelectAll();
            }
        }
        private void            EmailTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var tb = sender as TextBox;

            if (e.Key == Key.Enter)
            {
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                PhoneTB.SelectAll();
            }
        }
        private void            PhoneTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var tb = sender as TextBox;

            if (e.Key == Key.Enter)
            {
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                PasswordText.SelectAll();
            }
        }
        private async void      PasswordText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
