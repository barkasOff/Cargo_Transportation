using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand GOTOLoginPage { get; set; }

        public RegisterViewModel()
        {
            GOTOLoginPage = new RelayCommand(GOTOLoginPageMethodAsync);
        }

        private void GOTOLoginPageMethodAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
    }
}
