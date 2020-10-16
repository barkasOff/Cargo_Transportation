using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class                        UserPersonalAreaViewModel : BaseViewModel
    {
        public bool                     ShowPersonalArea { get; set; } = true;
        public TextEntryViewModel       FullName { get; set; }
        public TextEntryViewModel       PhoneNumber { get; set; }
        public TextEntryViewModel       Email { get; set; }
        public TextEntryViewModel       CompanyName { get; set; }
        public TextEntryViewModel       Login { get; set; }
        public PasswordEntryViewModel   Password { get; set; }

        /// <summary>
        /// TODO: normal information
        /// </summary>
        public UserPersonalAreaViewModel()
        {
            FullName = new TextEntryViewModel
            {
                Label = "ФИО",
                OriginalText = (IoC.Application_Work.Current_User as Client)?.FullName,
                MaxLength = 50
            };
            Login = new TextEntryViewModel
            {
                Label = "Логин",
                OriginalText = (IoC.Application_Work.Current_User as Client)?.Login,
                MaxLength = 20
            };
            PhoneNumber = new TextEntryViewModel
            {
                Label = "Номер телефона",
                OriginalText = (IoC.Application_Work.Current_User as Client)?.PhoneNumber,
                MaxLength = 11
            };
            Email = new TextEntryViewModel
            {
                Label = "Электронная почта",
                OriginalText = (IoC.Application_Work.Current_User as Client)?.Email,
                MaxLength = 50
            };
            CompanyName = new TextEntryViewModel
            {
                Label = "Название компании",
                OriginalText = (IoC.Application_Work.Current_User as Client)?.CompanyName,
                MaxLength = 20
            };
            Password = new PasswordEntryViewModel
            {
                Label = "Password",
                FakePassword = "*****"
            };
        }

        public void                     Update_User_PA()
        {
            FullName.OriginalText = (IoC.Application_Work.Current_User as Client)?.FullName;
            Login.OriginalText = (IoC.Application_Work.Current_User as Client)?.Login;
            PhoneNumber.OriginalText = (IoC.Application_Work.Current_User as Client)?.PhoneNumber;
            Email.OriginalText = (IoC.Application_Work.Current_User as Client)?.Email;
            CompanyName.OriginalText = (IoC.Application_Work.Current_User as Client)?.CompanyName;
        }
    }
}
