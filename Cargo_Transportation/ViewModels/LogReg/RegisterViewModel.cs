using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand Register { get; set; }
        public ICommand GOTOLoginPage { get; set; }

        public RegisterViewModel()
        {
            Register = new RelayCommand(RegisterMethod);
            GOTOLoginPage = new RelayCommand(GOTOLoginPageMethodAsync);
        }

        private void RegisterMethod()
        {
            IoC.Application.GoToPage(ApplicationPage.Driver);
        }
        private void GOTOLoginPageMethodAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
    }
}
