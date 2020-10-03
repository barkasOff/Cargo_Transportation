using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand Login { get; set; }
        public ICommand GOTORegisterPage { get; set; }

        public LoginViewModel()
        {
            Login = new RelayCommand(LoginMethod);
            GOTORegisterPage = new RelayCommand(GOTORegisterPageMethodAsync);
        }

        private void LoginMethod()
        {
            IoC.Application.GoToPage(ApplicationPage.UserPage);
        }
        private void GOTORegisterPageMethodAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Register);
        }
    }
}
