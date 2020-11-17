using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.AdminViewModels
{
	public class                                                AdminViewModel : BaseViewModel
    {
        public ObservableCollection<AdminEmployeeViewModel>     Drivers { get; set; }
        public ObservableCollection<AdminEmployeeViewModel>     Dispatchers { get; set; }
        public ObservableCollection<UserProductsViewModel>      Orders { get; set; }
        public AdminPAViewModel                                 AdminPAViewModel { get; set; }
        public CreateNewEmployeeViewModel                       CreateNewEmployeeViewModel { get; set; }
        public CreateNewCarViewModel                            CreateNewCarViewModel { get; set; }
        public bool                                             ShowAdminSidebar { get; set; } = true;
        public bool                                             ShowEmployees { get; set; }
        public bool                                             ShowOrdersToAdmin { get; set; }

        public ICommand                                         EmployeesCommand { get; set; }
        public ICommand                                         ShowSideBarCommand { get; set; }
        public ICommand                                         NewEmployeeCommand { get; set; }
        public ICommand                                         ShowNewCarCommand { get; set; }
        public ICommand                                         OrdersCommand { get; set; }
        public ICommand                                         PersonalInfoCommand { get; set; }
        public ICommand                                         ExitCommand { get; set; }

        public AdminViewModel()
        {
            Drivers = new ObservableCollection<AdminEmployeeViewModel>();
            Dispatchers = new ObservableCollection<AdminEmployeeViewModel>();
            Orders = new ObservableCollection<UserProductsViewModel>();
            AdminPAViewModel = new AdminPAViewModel();
            CreateNewEmployeeViewModel = new CreateNewEmployeeViewModel();
            CreateNewCarViewModel = new CreateNewCarViewModel();
            EmployeesCommand = new RelayCommand(EmployeesMethod);
            NewEmployeeCommand = new RelayCommand(ShowCreateNewEmployeeMethod);
            ShowNewCarCommand = new RelayCommand(ShowCreateNewCarMethod);
            PersonalInfoCommand = new RelayCommand(PersonalInfoMethod);
            OrdersCommand = new RelayCommand(OrdersToAdminMethod);
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));
            ShowSideBarCommand = new RelayCommand(() => ShowAdminSidebar = true);
        }

        public void                                             Update_PA()
        {
            AdminPAViewModel = new AdminPAViewModel()
            {
                FullName = (IoC.Application_Work.Current_User as Employee).FullName,
                PhoneNumber = (IoC.Application_Work.Current_User as Employee).PhoneNumber,
                Email = (IoC.Application_Work.Current_User as Employee).Email,
                Position = (IoC.Application_Work.Current_User as Employee).Position,
            };
        }
        public void                                             Set_Employees()
        {
            Drivers.Clear();
            Dispatchers.Clear();
            foreach (var user in IoC.Application_Work.All_Users)
            {
                if (user is Employee dr && dr.Position == "Driver")
                    Drivers.Add(Set_Employee(dr));
                else if (user is Employee dp && dp.Position == "Dispatcher")
                    Dispatchers.Add(Set_Employee(dp));
            }
        }
        public void                                             Set_Orders()
        {
            Orders.Clear();
            foreach (var order in IoC.Application_Work.All_Orders)
                if (order.Status == StatusOfProduct.Completed)
                    Orders.Add(IoC.DispatcherView.Make_UserProductsViewModel(order));
        }
		private void                                            Clear_Flags()
        {
            ShowAdminSidebar = false;
            AdminPAViewModel.ShowPA = false;
            ShowEmployees = false;
            CreateNewCarViewModel.ShowNewCar = false;
            CreateNewEmployeeViewModel.ShowCreateNewEmployee = false;
            ShowOrdersToAdmin = false;
        }
        private void                                            PersonalInfoMethod()
        {
            if (!AdminPAViewModel.ShowPA)
            {
                AdminPAViewModel.ShowPA = false;
                ShowEmployees = false;
                ShowOrdersToAdmin = false;
                CreateNewEmployeeViewModel.ShowCreateNewEmployee = false;
                CreateNewCarViewModel.ShowNewCar = false;
                AdminPAViewModel.ShowPA = true;
            }
        }
        private void                                            OrdersToAdminMethod()
        {
            if (!ShowOrdersToAdmin)
            {
                Set_Orders();
                Clear_Flags();
                ShowOrdersToAdmin = true;
            }
        }
        private void                                            ShowCreateNewEmployeeMethod()
        {
            if (!CreateNewEmployeeViewModel.ShowCreateNewEmployee)
            {
                Clear_Flags();
                CreateNewEmployeeViewModel.InitCars();
                CreateNewEmployeeViewModel.ShowCreateNewEmployee = true;
            }
        }
		private void		                                    ShowCreateNewCarMethod()
        {
            if (!CreateNewCarViewModel.ShowNewCar)
			{
				Clear_Flags();
                CreateNewCarViewModel.ShowNewCar = true;
            }
		}
        private void                                            EmployeesMethod()
        {
            if (!ShowEmployees)
            {
                Clear_Flags();
                ShowEmployees = true;
            }
        }
        private AdminEmployeeViewModel                          Set_Employee(Employee employee)
        {
            return (new AdminEmployeeViewModel()
            {
                EmployeeName = employee.FullName,
                Initials = employee.Position == "Driver" ? "В" : "Д",
                ProfilePictureRGB = employee.Position == "Driver" ? "e69ca7" : "9ce6bb",
                Employee = employee
            });
        }
    }
}
