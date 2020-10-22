using Cargo_Transportation.Check;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.Order;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class                                                UserPageViewModels : BaseViewModel
    {
        public ObservableCollection<UserProductsViewModel>      OutboxOrders { get; set; }
        public ObservableCollection<UserProductsViewModel>      InboxOrders { get; set; }
        public UserPersonalAreaViewModel                        PersonalAreaVM{ get; set; }
        public OrderViewModel                                   OrderViewModel{ get; set; }
        public bool                                             ShowOrders { get; set; }

        public                                                  ICommand ShowPersonalAreaCommand { get; set; }
        public                                                  ICommand ShowDoTheOrderCommand { get; set; }
        public                                                  ICommand ShowOrdersCommand { get; set; }
        public                                                  ICommand ExitCommand { get; set; }

        public UserPageViewModels()
        {
            PersonalAreaVM = new UserPersonalAreaViewModel();
            OrderViewModel = new OrderViewModel();

            ShowPersonalAreaCommand = new RelayCommand(ShowPersonalAreaMethod);
            ShowDoTheOrderCommand = new RelayCommand(ShowDoTheOrderMethod);
            ShowOrdersCommand = new RelayCommand(ShowOrdersMethod);
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));

            OutboxOrders = new ObservableCollection<UserProductsViewModel>();
            InboxOrders = new ObservableCollection<UserProductsViewModel>();
        }

        private void                                            CloseAll()
        {
            PersonalAreaVM.ShowPersonalArea = false;
            OrderViewModel.ShowDoTheOrder = false;
            ShowOrders = false;
        }
        private void                                            ShowOrdersMethod()
        {
            if (!ShowOrders)
            {
                CloseAll();
                ShowOrders = true;
            }
        }
        private void                                            ShowDoTheOrderMethod()
        {
            if (!OrderViewModel.ShowDoTheOrder)
            {
                CloseAll();
                OrderViewModel.ShowDoTheOrder = true;
            }
        }
        private void                                            ShowPersonalAreaMethod()
        {
            if (!PersonalAreaVM.ShowPersonalArea)
            { 
                CloseAll();
                PersonalAreaVM.ShowPersonalArea = true;
            }
        }
        private UserProductsViewModel                           Make_UserProductsViewModel(Product product)
        {
            Employee driver = null;
            var route = IoC.Application_Work.All_Routes.FirstOrDefault(r => r.Product?.Id == product.Id);
            var car = IoC.Application_Work.All_Cars.FirstOrDefault(r => r.Routes.FirstOrDefault(rot => rot.Id == route?.Id)?.Id == route?.Id);
            foreach (var u in IoC.Application_Work.All_Users)
                if (u is Employee dr && dr.CarId == product.Route?.CarId)
                    driver = dr;
            return (new UserProductsViewModel
            {
                Initials = "CL",
                ProfilePictureRGB = "89ccb7",
                Status = StringCheck.Convert_Order_Status(product.Status),
                UserName = (IoC.Application_Work.Current_User as Client).Login,
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
                    CarBrand = driver?.Car?.CarBrand ?? "Empty",
                    CarNumber = driver?.Car?.CarNumber ?? "Empty",
                    DispetcherName = driver?.Car?.CarBrand ?? "Empty",
                    DriverName = driver?.FullName ?? "Empty",
                    AdoptionDate = driver?.Car?.Routes.FirstOrDefault(rot => rot?.Id == route?.Id).ArrivalDate.ToShortDateString() ?? "Empty",
                },
                ShowVariablesOfDialog = StringCheck.Convert_Order_Status_To_Dialog(product.Status),
            });
        }
        public void                                             Set_Orders()
        {
            InboxOrders.Clear();
            OutboxOrders.Clear();
            foreach (var order in (IoC.Application_Work.Current_User as Client).Products)
            {
                if (order.OutgoingIncoming)
                    InboxOrders.Add(Make_UserProductsViewModel(order));
                else
                    OutboxOrders.Add(Make_UserProductsViewModel(order));
            }
        }
    }
}
