using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.Order;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.DriverViewModels
{
    public class                        DriverViewModel : EmployeeViewModel
    {
        private Car                     _car;

        public bool                     ShowAssignedOrder { get; set; }
        public string                   CommandText { get; set; }
        public OrderDialogViewModel     OrderDialogViewModel { get; set; }

        public ICommand                 ShowPersonalAreaCommand { get; set; }
        public ICommand                 ShowOrdersCommand { get; set; }
        public ICommand                 DriverCommand { get; set; }

        public DriverViewModel()
        {
            Orders = new ObservableCollection<UserProductsViewModel>();
            OrderDialogViewModel = new OrderDialogViewModel();
            ShowOrdersCommand = new RelayCommand(ShowOrdersMethod);
            ShowPersonalAreaCommand = new RelayCommand(ShowPersonalAreaMethod);
            DriverCommand = new RelayCommand(DriverMethod);
        }

        private async void              DriverMethod()
        {
            Route route = null;
            foreach (var r in IoC.Application_Work.All_Routes)
                if (r.CarId == _car.Id)
                    route = r;
            if (route == null)
                await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Title = "Error", Message = "You don't have any orders!!" });
            else if (route.Product.Status == StatusOfProduct.HoldDriverAccept)
            {
                WorkWithDB.Update_Product_Async(route.Product, StatusOfProduct.Current);
                await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Title = "Information", Message = "Good luck!!" });
                CommandText = "Delivered";
            }
            else
            {
                WorkWithDB.Update_Product_Async(route.Product, StatusOfProduct.Completed);
                WorkWithDB.Remove_Car_Route(_car);
                await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Title = "Congratulations", Message = "Well done!!" });
                CommandText = "No command";
                OrderDialogViewModel = new OrderDialogViewModel();
            }
        }
        private void                    ShowPersonalAreaMethod()
        {
            ShowAssignedOrder = false;
            EmployeePAViewModel.ShowPersonalArea = true;
        }
        private void                    ShowOrdersMethod()
        {
            ShowAssignedOrder = true;
            EmployeePAViewModel.ShowPersonalArea = false;
        }
        public void                     Assigned_Order()
        {
            Route rt = null;
            var car = (IoC.Application_Work.Current_User as Employee).Car;

            foreach (var r in IoC.Application_Work.All_Routes)
                if (r.CarId == car?.Id && (r.Product.Status == StatusOfProduct.Current || r.Product.Status == StatusOfProduct.HoldDriverAccept))
                    rt = r;
            if (car != null)
            {
                var route = rt;
                var product = route?.Product;
                OrderDialogViewModel = new OrderDialogViewModel()
                {
                    OrderName = product?.Name ?? "Empty",
                    OrderWeight = product?.ProductWeight.ToString() ?? "Empty",
                    From = route != null ? route?.From : "Empty",
                    To = route != null ? route?.To : "Empty",
                    DeliveryDate = route != null ? DateTime.Parse(route.DepartureDate.ToString()).ToShortDateString() : "Empty",
                    CarBrand = car?.CarBrand ?? "Empty",
                    CarNumber = car?.CarNumber ?? "Empty",
                    DispetcherName = car?.CarBrand ?? "Empty",
                    DriverName = (IoC.Application_Work.Current_User as Employee).FullName ?? "Empty",
                    AdoptionDate = route?.ArrivalDate.ToShortDateString() ?? "Empty",
                };
                _car = car;
            }
            if (rt == null)
                CommandText = "No command";
            else if (rt.Product.Status == StatusOfProduct.HoldDriverAccept)
                CommandText = "Accept";
            else
                CommandText = "Delivered";
        }
    }
}
