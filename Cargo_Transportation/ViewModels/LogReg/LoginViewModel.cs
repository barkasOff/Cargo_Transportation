using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand Login { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand GOTORegisterPage { get; set; }

        public LoginViewModel()
        {
            Login = new RelayCommand(LoginMethod);
            Cancel = new RelayCommand(CancelMethod);
            GOTORegisterPage = new RelayCommand(GOTORegisterPageMethodAsync);
        }

        private void LoginMethod()
        {
            IoC.Application.GoToPage(ApplicationPage.UserPage);
        }
        private void CancelMethod()
        {
            IoC.Application.GoToPage(ApplicationPage.DispatcherPage);
        }
        private void GOTORegisterPageMethodAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Register);
        }
    }
}
