using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Security;
using Cargo_Transportation.ViewModels.Base;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.Input
{
    public class                PasswordEntryViewModel : BaseViewModel
    {
        public string           Label { get; set; }
        public string           FakePassword { get; set; }
        public string           CurrentPasswordHintText { get; set; }
        public string           NewPasswordHintText { get; set; }
        public string           ConfirmPasswordHintText { get; set; }
        public SecureString     CurrentPassword { get; set; }
        public SecureString     NewPassword { get; set; }
        public SecureString     ConfirmPassword { get; set; }
        public bool             Editing { get; set; }
        public bool             Working { get; set; }

        public ICommand         EditCommand { get; set; }
        public ICommand         CancelCommand { get; set; }
        public ICommand         SaveCommand { get; set; }

        public PasswordEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommandParameter(async (parameter) => await SaveAsync(parameter));
            // TODO: Replace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        public void             Edit()
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();
            Editing = true;
        }
        public void             Cancel()
        {
            Editing = false;
        }
        public async Task       SaveAsync(object parameter)
        {
            var curpass = (parameter as IChangePassword)?.CurPass?.Unsecure();
            var newpass = (parameter as IChangePassword)?.NewPass?.Unsecure();
            var repnewpass = (parameter as IChangePassword)?.RepNewPass?.Unsecure();

            if (curpass != IoC.Application_Work.Current_User.Parol)
                await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Set the correct current password!!", Title = "Error" });
            else if (newpass != repnewpass)
                await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Not the same input passwords!!", Title = "Error" });
            else
            {
                // TODO: Validation
                IoC.Application_Work.Current_User.Parol = newpass;
                WorkWithDB.UpdateUserInfo(IoC.Application_Work.Current_User, UpdateClientData.Password);
                Editing = false;
            }
        }
    }
}
