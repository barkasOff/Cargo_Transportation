using Cargo_Transportation.Check;
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
        public bool         SelectLogin{ get; set; }
        public bool         SelectPassword { get; set; }

        public ICommand     Register { get; set; }
        public ICommand     Cancel { get; set; }
        public ICommand     GOTOLoginPage { get; set; }

        public RegisterViewModel()
        {
            Register = new RelayCommandParameter(async (parameter) => await RegisterMethodAsync(parameter));
            Cancel = new RelayCommandParameter(CancelMethod);
            GOTOLoginPage = new RelayCommand(GOTOLoginPageMethodAsync);
        }


        private bool        Check_Password(string password)
        {
            if (password == string.Empty || !CheckInputData.CheckLatin(password) ||
                                            !CheckInputData.PasswordCheck(password))
                _message = "Неправильный пароль!!";
            return (password != string.Empty && CheckInputData.PasswordCheck(password)
            && CheckInputData.CheckLatin(password));
        }
        private bool        Check_Login()
        {
            if (Login == string.Empty || !CheckInputData.CheckLatin(Login) ||
                                         !CheckInputData.LoginCheck(Login))
                _message = "Неправильный логин!!";
            return (Login != string.Empty && CheckInputData.CheckLatin(Login) &&
            CheckInputData.LoginCheck(Login));
        }
        private bool        Check_Email()
        {
            if (Email == string.Empty || CheckInputData.CheckLatin(Email) == false
                                      || CheckInputData.EmailCheck(Email) == false)
                _message = "Неправильная почта!!";
            return (Email != string.Empty && CheckInputData.CheckLatin(Email)
            && CheckInputData.EmailCheck(Email));
        }
        private bool        Check_Phone()
        {
            if (Phone == string.Empty || !CheckInputData.NumberCheck(Phone)
                                      || !CheckInputData.PhoneCheck(Phone))
                _message = "Неправильный номер телефона!!";
            return (Phone != string.Empty && CheckInputData.NumberCheck(Phone) && CheckInputData.PhoneCheck(Phone));
        }
        private async Task  RegisterMethodAsync(object parameter)
        {
            string password = (parameter as IHavePassword)?.SecurePassword?.Unsecure() ?? "";
            if (Check_Password(password) && Check_Login() && Check_Email() && Check_Phone())
            {
                var user = new Client() { Login = this.Login, Parol = password, Email = this.Email, PhoneNumber = Phone };

                WorkWithDB.Set_User_Async(user);
                _message = "Успех!";
                IoC.Application.GoToPage(ApplicationPage.Login);
            }
            await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Message = _message, Title = "Error" });
        }
        private void        CancelMethod(object obj)
        {
            Login = "";
            Email = "";
            Phone = "";
            SelectPassword = true;
            SelectPassword = false;
        }
        private void        GOTOLoginPageMethodAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
        }
    }
}
