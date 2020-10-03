using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.Input;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class UserPageViewModels : BaseViewModel
    {
        public bool ShowPersonalArea { get; set; } = true;
        public bool ShowDoTheOrder { get; set; }
        public bool ShowOrders { get; set; }
        public TextEntryViewModel FullName { get; set; }
        public TextEntryViewModel PhoneNumber { get; set; }
        public TextEntryViewModel Email { get; set; }
        public TextEntryViewModel CompanyName { get; set; }
        public TextEntryViewModel Login { get; set; }

        public ICommand ShowPersonalAreaCommand { get; set; }
        public ICommand ShowDoTheOrderCommand { get; set; }
        public ICommand ShowOrdersCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        /// <summary>
        /// TODO: normal information
        /// </summary>
        public UserPageViewModels()
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

            ShowPersonalAreaCommand = new RelayCommand(ShowPersonalAreaMethod);
            ShowDoTheOrderCommand = new RelayCommand(ShowDoTheOrderMethod);
            ShowOrdersCommand = new RelayCommand(ShowOrdersMethod);
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));
        }

        private void CloseAll()
        {
            ShowPersonalArea = false;
            ShowDoTheOrder = false;
            ShowOrders = false;
        }
        private void ShowOrdersMethod()
        {
            if (!ShowOrders)
            {
                CloseAll();
                ShowOrders = true;
            }
        }
        private void ShowDoTheOrderMethod()
        {
            if (!ShowDoTheOrder)
            {
                CloseAll();
                ShowDoTheOrder = true;
            }
        }
        private void ShowPersonalAreaMethod()
        {
            if (!ShowPersonalArea)
            { 
                CloseAll();
            }
            ShowPersonalArea = true;
        }
    }
}
