using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.AdminViewModels
{
    public class            CreateNewEmployeeViewModel : BaseViewModel
    {
        public bool         ShowCreateNewEmployee { get; set; }
        public string       FullName { get; set; }
        public string       Phone { get; set; }
        public string       Email { get; set; }
        public string       Position { get; set; }
        public string       Login { get; set; }
        public string       Password { get; set; }

        public ICommand     CreateNewEmployeeCommand { get; set; }

        public CreateNewEmployeeViewModel()
        {
            CreateNewEmployeeCommand = new RelayCommand(CreateNewEmployeeMethod);
        }

        private void CreateNewEmployeeMethod()
        {
            // TODO: Валидация данных
            WorkWithDB.Set_User_Async(new Employee()
            {
                Login = this.Login,
                Parol = Password,
                FullName = this.FullName,
                PhoneNumber = this.Phone,
                Email = this.Email,
                Position = this.Position,
                Salary = this.Position == "Driver" ? 50000 : 70000,
                Task = this.Position == "Driver" ? "Take and deliver orders" : "Accept and distribute orders",
            });
            Login = "";
            Password = "";
            FullName = "";
            Phone = "";
            Email = "";
            Position = "";
            IoC.AdminView.Set_Employees();
            IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Message = "Сотрудник создан!!", Title = "Success" });
        }
    }
}
