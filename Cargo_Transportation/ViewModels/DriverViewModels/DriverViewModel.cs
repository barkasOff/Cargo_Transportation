using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.DriverViewModels
{
    public class                                            DriverViewModel : EmployeeViewModel
    {
        public bool                                         HasOrder { get; set; }

        public ICommand                                     ShowPersonalAreaCommand { get; set; }
        public ICommand                                     ShowOrdersCommand { get; set; }

        public DriverViewModel()
        {
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
        }

        private void                                        ShowPersonalAreaMethod()
        {
            IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.OrderToTheDriver;
            ShowAllOrders = false;
            EmployeePAViewModel.ShowPersonalArea = true;
        }
        private void                                        ShowOrdersMethod()
        {
            IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.OrderToTheDriver;
            ShowAllOrders = true;
            EmployeePAViewModel.ShowPersonalArea = false;
        }
    }
}
