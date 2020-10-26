using Cargo_Transportation.Check;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.Order;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.DispatcherViewModels
{
    public class                                            DispatcherViewModels : EmployeeViewModel
    {
        public ObservableCollection<UserProductsViewModel>  ConfirmOrders { get; set; }
        public ObservableCollection<UserProductsViewModel>  CurrentOrders { get; set; }
        public ObservableCollection<UserProductsViewModel>  NewOrders { get; set; }
        public bool                                         ShowDispatcherSidebar { get; set; } = true;
        public string                                       OrderStatus { get; set; }

        public ICommand                                     ShowSideBarCommand { get; set; }
        public ICommand                                     AllNewOrdersCommand { get; set; }
        public ICommand                                     CurrentOrdersCommand { get; set; }
        public ICommand                                     ConfirmOrdersCommand { get; set; }
        public ICommand                                     PersonalInfoCommand { get; set; }

        public DispatcherViewModels()
        {
            ConfirmOrders = new ObservableCollection<UserProductsViewModel>();
            CurrentOrders = new ObservableCollection<UserProductsViewModel>();
            NewOrders = new ObservableCollection<UserProductsViewModel>();

            ShowSideBarCommand = new RelayCommand(() => ShowDispatcherSidebar = true);
            AllNewOrdersCommand = new RelayCommand(AllNewOrdersMethod);
            CurrentOrdersCommand = new RelayCommand(CurrentOrdersMethod);
            ConfirmOrdersCommand = new RelayCommand(ConfirmOrdersMethod);
            PersonalInfoCommand = new RelayCommand(PersonalInfoMethod);
        }

        private void                                        PersonalInfoMethod()
        {
            ShowDispatcherSidebar = true;
            ShowAllOrders = false;
            EmployeePAViewModel.ShowPersonalArea = true;
        }
        private void                                        HideUnnecessaryInfo()
        {
            ShowDispatcherSidebar = false;
            ShowAllOrders = true;
            EmployeePAViewModel.ShowPersonalArea = false;
        }
        private void                                        ConfirmOrdersMethod()
        {
            OrderStatus = "Confirm Orders";
            Orders = ConfirmOrders;
            HideUnnecessaryInfo();
        }
        private void                                        CurrentOrdersMethod()
        {
            OrderStatus = "Current Orders";
            Orders = CurrentOrders;
            HideUnnecessaryInfo();
        }
        private void                                        AllNewOrdersMethod()
        {
            OrderStatus = "Processing Orders";
            Orders = NewOrders;
            HideUnnecessaryInfo();
        }
        public UserProductsViewModel                        Make_UserProductsViewModel(Product product)
        {
            Employee driver = null;
            string login = "";
            foreach (var el in IoC.Application_Work.All_Users)
                if (el is Client client && client?.Products.FirstOrDefault(u => u.Id == product.Id) != null)
                        login = el.Login;
            var route = IoC.Application_Work.All_Routes.FirstOrDefault(r => r.Product?.Id == product.Id);
            var car = IoC.Application_Work.All_Cars.FirstOrDefault(r => r.Routes.FirstOrDefault(rot => rot?.Id == route?.Id)?.Id == route?.Id);
            foreach (var dr in IoC.Application_Work.All_Users)
                if (dr is Employee driv && driv?.CarId == car?.Id)
                    driver = (dr as Employee);
            return (new UserProductsViewModel
            {
                Initials = "CL",
                ProfilePictureRGB = "89ccb7",
                Status = StringCheck.Convert_Order_Status(product.Status == StatusOfProduct.Inpprocessing ? StatusOfProduct.DispetcherInpprocessing : product.Status),
                UserName = login,
                StatusColor = product.Status == StatusOfProduct.Completed ? "00c541" : product.Status == StatusOfProduct.Current ? "ff4747" : "0080ff",
                ProductName = product.Name,
                Product = product,
                OrderDialogViewModel = new OrderDialogViewModel
                {
                    OrderName = product.Name ?? "Empty",
                    OrderWeight = product.ProductWeight.ToString() ?? "Empty",
                    From = route != null ? route.From : "Empty",
                    To = route != null ? route.To : "Empty",
                    DeliveryDate = route != null ? DateTime.Parse(route.DepartureDate.ToString()).ToShortDateString() : "Empty",
                    DeliveryCost = route?.DeliveryCost.ToString() ?? "Empty",
                    CarBrand = car?.CarBrand ?? "Empty",
                    CarNumber = car?.CarNumber ?? "Empty",
                    DispetcherName = car?.CarBrand ?? "Empty",
                    DriverName = driver?.FullName ?? "Empty",
                    AdoptionDate = car?.Routes.FirstOrDefault(rot => rot?.Id == route?.Id)?.ArrivalDate.ToShortDateString() ?? "Empty",
                },
                ShowVariablesOfDialog = StringCheck.Convert_Order_Status_To_Dialog(product.Status == StatusOfProduct.Inpprocessing ? StatusOfProduct.DispetcherInpprocessing : product.Status),
            });
        }
        public void                                         Set_Orders()
        {
            NewOrders.Clear();
            ConfirmOrders.Clear();
            CurrentOrders.Clear();
            foreach (var order in IoC.Application_Work.All_Orders)
            {
                if (order.Status == StatusOfProduct.Inpprocessing || order.Status == StatusOfProduct.HoldDispetcherToDriverAccept)
                    NewOrders.Add(Make_UserProductsViewModel(order));
                else if (order.Status == StatusOfProduct.Current)
                    CurrentOrders.Add(Make_UserProductsViewModel(order));
                else if (order.Status == StatusOfProduct.Completed)
                    ConfirmOrders.Add(Make_UserProductsViewModel(order));
            }
        }
        public void                                         Reload_Orders()
        {
            NewOrders.Clear();
            foreach (var order in IoC.Application_Work.All_Orders)
                if (order.Status == StatusOfProduct.Inpprocessing)
                    NewOrders.Add(Make_UserProductsViewModel(order));
        }
        public void                                         Add_New_Order(UserProductsViewModel userProductsViewModel)
        {
            NewOrders.Add(userProductsViewModel);
        }
    }
}
