using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand GOTORegisterPage { get; set; }

        public LoginViewModel()
        {
            GOTORegisterPage = new RelayCommand(GOTORegisterPageMethod);
        }

        private void GOTORegisterPageMethod()
        {
            IoC.IoC.Application.GoToPage(ApplicationPage.Register);
        }
    }
}
