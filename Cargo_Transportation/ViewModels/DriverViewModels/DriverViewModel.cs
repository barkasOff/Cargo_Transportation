using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.DriverViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        public DriverPAViewModel DriverPAViewModel { get; set; }
        public ObservableCollection<UserProductsViewModel> Orders { get; set; }
        public bool HasOrder { get; set; }
        public bool ShowOrders { get; set; }

        public ICommand ShowPersonalAreaCommand { get; set; }
        public ICommand ShowOrdersCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public DriverViewModel()
        {
            DriverPAViewModel = new DriverPAViewModel();
            Orders = new ObservableCollection<UserProductsViewModel>();
            for (int i = 0; i < 9; i++)
            {
                Orders.Add(
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Confirm",
                    UserName = "Antosha",
                    StatusColor = "00c541",
                    ProductName = "Трусы"
                });
            }

            ShowOrdersCommand = new RelayCommand(ShowOrdersMethod);
            ShowPersonalAreaCommand = new RelayCommand(ShowPersonalAreaMethod);
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));
        }

        private void ShowPersonalAreaMethod()
        {
            IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.OrderToTheDriver;
            ShowOrders = false;
            DriverPAViewModel.ShowDriverPersonalArea = true;
        }
        private void ShowOrdersMethod()
        {
            IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.OrderToTheDriver;
            ShowOrders = true;
            DriverPAViewModel.ShowDriverPersonalArea = false;
        }
    }
}
