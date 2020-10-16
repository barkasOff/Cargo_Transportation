using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        private UserProductsViewModel                       Make_UserProductsViewModel(Product product)
        {
            string login = "";
            foreach (var el in IoC.Application_Work.All_Users)
                if (el is Client client && client?.Products.FirstOrDefault(u => u.Id == product.Id) != null)
                        login = el.Login;
            return (new UserProductsViewModel
            {
                Initials = "CL",
                ProfilePictureRGB = "89ccb7",
                Status = product.Status == StatusOfProduct.Completed ? "Confirm" : product.Status == StatusOfProduct.Current ? "Current" : "Inprocessing",
                UserName = login,
                StatusColor = product.Status == StatusOfProduct.Completed ? "00c541" : product.Status == StatusOfProduct.Current ? "ff4747" : "0080ff",
                ProductName = product.Name
            });
        }
        public async void                                   Set_Orders_Async()
        {
            foreach (var order in IoC.Application_Work.All_Orders)
            {
                if (order.Status == StatusOfProduct.Inpprocessing)
                    await Task.Run(() => NewOrders.Add(Make_UserProductsViewModel(order)));
                else if (order.Status == StatusOfProduct.Current)
                    await Task.Run(() => CurrentOrders.Add(Make_UserProductsViewModel(order)));
                else if (order.Status == StatusOfProduct.Completed)
                    await Task.Run(() => ConfirmOrders.Add(Make_UserProductsViewModel(order)));
            }
        }
        public void                                         Add_New_Order(UserProductsViewModel userProductsViewModel)
        {
            NewOrders.Add(userProductsViewModel);
        }
    }
}
