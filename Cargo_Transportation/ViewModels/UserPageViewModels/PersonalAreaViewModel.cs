using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class PersonalAreaViewModel : BaseViewModel
    {
        public bool ShowPersonalArea { get; set; } = true;
        public TextEntryViewModel FullName { get; set; }
        public TextEntryViewModel PhoneNumber { get; set; }
        public TextEntryViewModel Email { get; set; }
        public TextEntryViewModel CompanyName { get; set; }
        public TextEntryViewModel Login { get; set; }
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// TODO: normal information
        /// </summary>
        public PersonalAreaViewModel()
        {
            FullName = new TextEntryViewModel
            {
                Label = "ФИО",
                OriginalText = "Сизов Борис Александрович",
                MaxLength = 50
            };
            Login = new TextEntryViewModel
            {
                Label = "Логин",
                OriginalText = "barkasOff",
                MaxLength = 20
            };
            PhoneNumber = new TextEntryViewModel
            {
                Label = "Номер телефона",
                OriginalText = "89196916135",
                MaxLength = 11
            };
            Email = new TextEntryViewModel
            {
                Label = "Электронная почта",
                OriginalText = "boris.sizov.2001@mail.ru",
                MaxLength = 50
            };
            CompanyName = new TextEntryViewModel
            {
                Label = "Название компании",
                OriginalText = "B o r o v",
                MaxLength = 20
            };
            Password = new PasswordEntryViewModel
            {
                Label = "Password",
                FakePassword = "*****"
            };
        }
    }
}
