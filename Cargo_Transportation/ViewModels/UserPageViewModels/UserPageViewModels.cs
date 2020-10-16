using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            return (new UserProductsViewModel
            {
                Initials = "CL",
                ProfilePictureRGB = "89ccb7",
                Status = product.Status == StatusOfProduct.Completed ? "Confirm" : product.Status == StatusOfProduct.Current ? "Current" : "Inprocessing",
                UserName = (IoC.Application_Work.Current_User as Client).Login,
                StatusColor = product.Status == StatusOfProduct.Completed ? "00c541" : product.Status == StatusOfProduct.Current ? "ff4747" : "0080ff",
                ProductName = product.Name
            });
        }
        public async void                                       Set_Orders_Async()
        {
            foreach (var order in (IoC.Application_Work.Current_User as Client).Products)
            {
                if (order.OutgoingIncoming)
                    await Task.Run(() => InboxOrders.Add(Make_UserProductsViewModel(order)));
                else
                    await Task.Run(() => OutboxOrders.Add(Make_UserProductsViewModel(order)));
            }
        }
    }
}
