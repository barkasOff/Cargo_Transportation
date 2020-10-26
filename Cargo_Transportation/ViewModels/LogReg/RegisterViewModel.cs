using Cargo_Transportation.DBProvider;
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
    public class            RegisterViewModel : BaseViewModel
    {
        private string      _message;

        public string       Login { get; set; }
        public string       Email { get; set; }
        public string       Phone { get; set; }

        public ICommand     Register { get; set; }
        public ICommand     GOTOLoginPage { get; set; }

        public RegisterViewModel()
        {
            Register = new RelayCommandParameter(async (parameter) => await RegisterMethodAsync(parameter));
            GOTOLoginPage = new RelayCommand(GOTOLoginPageMethodAsync);
        }

        // TODO: Validation
        private bool        Check_Password(string password)
        {
            if (password == string.Empty)
                _message = "Incorrect password!!";
            return (password != string.Empty);
        }
        private bool        Check_Login()
        {
            if (Login == string.Empty)
                _message = "Incorrect login!!";
            return (Login != string.Empty);
        }
        private bool        Check_Email()
        {
            if (Email == string.Empty)
                _message = "Incorrect email!!";
            return (Email != string.Empty);
        }
        private bool        Check_Phone()
        {
            if (Phone == string.Empty)
                _message = "Incorrect phone!!";
            return (Phone != string.Empty);
        }
        private async Task  RegisterMethodAsync(object parameter)
        {
            string password = (parameter as IHavePassword)?.SecurePassword?.Unsecure() ?? "";
            if (Check_Password(password) && Check_Login()&& Check_Email()&& Check_Phone())
            {
                var user = new Client() { Login = this.Login, Parol = password, Email = this.Email, PhoneNumber = Phone };

                WorkWithDB.Set_User_Async(user);
                _message = "Success!! Thank you!!";
                IoC.Application.GoToPage(ApplicationPage.Login);
            }
            await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Message = _message, Title = "Error" });
        }
        private void        GOTOLoginPageMethodAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
    }
}
