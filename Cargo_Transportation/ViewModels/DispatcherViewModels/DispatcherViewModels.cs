using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.DispatcherViewModels
{
    public class DispatcherViewModels : BaseViewModel
    {
        public ObservableCollection<UserProductsViewModel> ConfirmOrders { get; set; }
        public ObservableCollection<UserProductsViewModel> CurrentOrders { get; set; }
        public ObservableCollection<UserProductsViewModel> NewOrders { get; set; }
        public ObservableCollection<UserProductsViewModel> Orders { get; set; }
        public DispatcherPAViewModel DispatcherPAViewModel { get; set; }
        public bool ShowDispatcherSidebar { get; set; } = true;
        public bool ShowAllOrders { get; set; }
        public string OrderStatus { get; set; }

        public ICommand ShowSideBarCommand { get; set; }
        public ICommand AllNewOrdersCommand { get; set; }
        public ICommand CurrentOrdersCommand { get; set; }
        public ICommand ConfirmOrdersCommand { get; set; }
        public ICommand PersonalInfoCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public DispatcherViewModels()
        {
            ConfirmOrders = new ObservableCollection<UserProductsViewModel>();
            for (int i = 0; i < 9; i++)
            {
                ConfirmOrders.Add(
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
            CurrentOrders = new ObservableCollection<UserProductsViewModel>();
            for (int i = 0; i < 9; i++)
            {
                CurrentOrders.Add(
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Awaiting delivery",
                    UserName = "Antosha",
                    StatusColor = "0080ff",
                    ProductName = "Трусы"
                });
            }
            NewOrders = new ObservableCollection<UserProductsViewModel>();
            for (int i = 0; i < 9; i++)
            {
                NewOrders.Add(
                new UserProductsViewModel
                {
                    Initials = "CL",
                    ProfilePictureRGB = "89ccb7",
                    Status = "Pending processing",
                    UserName = "Antosha",
                    StatusColor = "ff4747",
                    ProductName = "Трусы"
                });
            }
            DispatcherPAViewModel = new DispatcherPAViewModel();

            ShowSideBarCommand = new RelayCommand(() => ShowDispatcherSidebar = true);
            AllNewOrdersCommand = new RelayCommand(AllNewOrdersMethod);
            CurrentOrdersCommand = new RelayCommand(CurrentOrdersMethod);
            ConfirmOrdersCommand = new RelayCommand(ConfirmOrdersMethod);
            PersonalInfoCommand = new RelayCommand(PersonalInfoMethod);
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));
        }

        private void PersonalInfoMethod()
        {
            if (IoC.Application.OrderProcessingOrInformation != ShowVariablesOfDialog.ShowOrderProcessing)
                IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.ShowOrderProcessing;
            ShowDispatcherSidebar = true;
            ShowAllOrders = false;
            DispatcherPAViewModel.ShowDispatcherPersonalArea = true;
        }
        private void HideUnnecessaryInfo()
        {
            ShowDispatcherSidebar = false;
            ShowAllOrders = true;
            DispatcherPAViewModel.ShowDispatcherPersonalArea = false;
        }
        private void ConfirmOrdersMethod()
        {
            if (IoC.Application.OrderProcessingOrInformation != ShowVariablesOfDialog.ShowOrderInformationAfterConfirmation)
                IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.ShowOrderInformationAfterConfirmation;
            OrderStatus = "Confirm Orders";
            Orders = ConfirmOrders;
            HideUnnecessaryInfo();
        }
        private void CurrentOrdersMethod()
        {
            OrderStatus = "Current Orders";
            Orders = CurrentOrders;
            HideUnnecessaryInfo();
        }
        private void AllNewOrdersMethod()
        {
            if (IoC.Application.OrderProcessingOrInformation != ShowVariablesOfDialog.ShowOrderProcessing)
                IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.ShowOrderProcessing;
            OrderStatus = "Processing Orders";
            Orders = NewOrders;
            HideUnnecessaryInfo();
        }
    }
}
