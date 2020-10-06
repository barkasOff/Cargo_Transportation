using Cargo_Transportation.ViewModels.Base;
using System.Security;
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
            SaveCommand = new RelayCommand(Save);
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
        public void             Save()
        {

        }
    }
}
