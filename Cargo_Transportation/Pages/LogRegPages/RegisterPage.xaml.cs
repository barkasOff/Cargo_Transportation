using Cargo_Transportation.ViewModels.LogReg;

namespace Cargo_Transportation.Pages.LogRegPages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage
    {
        public RegisterPage()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }
    }
}
