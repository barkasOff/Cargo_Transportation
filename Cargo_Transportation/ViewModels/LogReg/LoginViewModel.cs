using Cargo_Transportation.Check;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Models;
using Cargo_Transportation.Security;
using Cargo_Transportation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class                LoginViewModel : BaseViewModel
    {
        public string           Login { get; set; }

        public ICommand         LoginCommand { get; set; }
        public ICommand         CancelCommand { get; set; }
        public ICommand         GOTORegisterPageCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommandParameter(async (parameter) => await LoginMethodAsync(parameter));
            CancelCommand = new RelayCommand(CancelMethod);
            GOTORegisterPageCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Register));
        }

        private async Task      LoginMethodAsync(object parameter)
        {
            string password = (parameter as IHavePassword)?.SecurePassword?.Unsecure();
            switch (LoginRegisterCheck.Which_User(Login, password))
            {
                case AplicationUser.User:
                    IoC.Application.GoToPage(ApplicationPage.UserPage);
                    break;
                case AplicationUser.Dispatcher:
                    IoC.Application.GoToPage(ApplicationPage.DispatcherPage);
                    break;
                case AplicationUser.Driver:
                    IoC.Application.GoToPage(ApplicationPage.Driver);
                    break;
                default:
                    await IoC.UI.ShowMessage(new MessageBoxDialogViewModel(new Product(StatusOfProduct.Completed)) { Title = "Who are you?" });
                    break;
            }
        }
        private void            CancelMethod()
        {
            Login = "";
        }
    }
}
