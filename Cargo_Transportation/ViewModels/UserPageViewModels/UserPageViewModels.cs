using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class UserPageViewModels : BaseViewModel
    {
        public ObservableCollection<UserProductsViewModel> OutboxOrders { get; set; }
        public ObservableCollection<UserProductsViewModel> InboxOrders { get; set; }
        public PersonalAreaViewModel PersonalAreaVM{ get; set; }
        public bool ShowDoTheOrder { get; set; }
        public bool ShowOrders { get; set; }

        public ICommand ShowPersonalAreaCommand { get; set; }
        public ICommand ShowDoTheOrderCommand { get; set; }
        public ICommand ShowOrdersCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public UserPageViewModels()
        {
            PersonalAreaVM = new PersonalAreaViewModel();

            ShowPersonalAreaCommand = new RelayCommand(ShowPersonalAreaMethod);
            ShowDoTheOrderCommand = new RelayCommand(ShowDoTheOrderMethod);
            ShowOrdersCommand = new RelayCommand(ShowOrdersMethod);
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));

            OutboxOrders = new ObservableCollection<UserProductsViewModel>
            {
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Current",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "00c541",
                    ProductName = "Трусы"
                },
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Completed",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "ff4747",
                    ProductName = "Компьютеры"
                },
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Inpprocessing",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "0080ff",
                    ProductName = "Телефоны"
                },
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Test",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "0080ff",
                    ProductName = "Носки"
                },
            };
            InboxOrders = new ObservableCollection<UserProductsViewModel>
            {
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Test",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "0080ff",
                    ProductName = "Футболки"
                },
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Test",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "0080ff",
                    ProductName = "Доски"
                },
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Test",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "0080ff",
                    ProductName = "Холодильники"
                },
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Test",
                    UserName = PersonalAreaVM.FullName.OriginalText,
                    StatusColor = "0080ff",
                    ProductName = "Кофты"
                },
            };
        }

        private void CloseAll()
        {
            PersonalAreaVM.ShowPersonalArea = false;
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
            if (!PersonalAreaVM.ShowPersonalArea)
            { 
                CloseAll();
                PersonalAreaVM.ShowPersonalArea = true;
            }
        }
    }
}
