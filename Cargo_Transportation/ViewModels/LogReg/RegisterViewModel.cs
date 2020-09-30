using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand GOTOLoginPage { get; set; }

        public RegisterViewModel()
        {
            GOTOLoginPage = new RelayCommand(GOTOLoginPageMethod);
        }

        private void GOTOLoginPageMethod()
        {
            IoC.IoC.Application.GoToPage(ApplicationPage.Login);
        }
    }
}
