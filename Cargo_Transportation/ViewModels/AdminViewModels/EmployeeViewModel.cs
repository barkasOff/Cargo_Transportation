using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.AdminViewModels
{
    public class            AdminEmployeeViewModel : BaseViewModel
    {
        public string       Initials { get; set; }
        public string       ProfilePictureRGB { get; set; }
        public string       EmployeeName { get; set; }
        public Employee     Employee { get; set; }

        public ICommand     ShowEmployeeInfoCommand { get; set; }

        public AdminEmployeeViewModel()
        {
            ShowEmployeeInfoCommand = new RelayCommand(ShowEmployeeInfoMethod);
        }

        private void ShowEmployeeInfoMethod()
        {
            IoC.UI.EmployeeInfo(new EmployeeDialoViewModel()
            {
                FullName = EmployeeName,
                Email = Employee.Email,
                PhoneNumber = Employee.PhoneNumber,
                Position = Employee.Position,
                Title = "Employee Information"
            });
        }
    }
}
