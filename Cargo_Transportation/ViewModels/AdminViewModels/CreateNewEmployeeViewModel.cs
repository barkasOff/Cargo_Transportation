using Cargo_Transportation.Check;
using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.AdminViewModels
{
	public class                            CreateNewEmployeeViewModel : BaseViewModel
    {
        private List<string>                Cars;
        public string                       SelectedCar { get; set; }
        public int                          SelectedCarIndex { get; set; } = 0;
        public bool                         ShowCreateNewEmployee { get; set; }
        public bool                         IsSetCar { get; set; }
        public string                       FullName { get; set; }
        public string                       Phone { get; set; }
        public string                       Email { get; set; }
        public string                       Position { get; set; }
        public string                       Login { get; set; }
        public string                       Password { get; set; }

        public ICommand                     CreateNewEmployeeCommand { get; set; }
        public ICommand                     NextCarCommand { get; set; }

        public CreateNewEmployeeViewModel()
        {
            Cars = new List<string>();
            CreateNewEmployeeCommand = new RelayCommand(CreateNewEmployeeMethod);
            NextCarCommand = new RelayCommand(NextCarMethod);
			PropertyChanged += CreateNewEmployeeViewModel_PropertyChanged;
        }

		private void                        NextCarMethod()
        {
            if (Cars.Count > 0)
            {
                SelectedCar = Cars[SelectedCarIndex];
                ++SelectedCarIndex;
                if (SelectedCarIndex >= Cars.Count)
                    SelectedCarIndex = 0;
            }
        }
		private void                        CreateNewEmployeeViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
            if (e.PropertyName == "Position")
            {
                if (Position == "Driver")
                    IsSetCar = true;
                else
                    IsSetCar = false;
            }
        }
        public string                       GetId()
		{
            string res = "";
            foreach (var ch in SelectedCar)
            {
                if (ch == '.')
                    break ;
                res += ch;
            }
            return (res);
        }
		public void                         InitCars()
        {
            Cars.Clear();
            foreach (var car in IoC.Application_Work.All_Cars)
                Cars.Add($"{car.Id}. {car.CarBrand} - {car.CarNumber} - {car.CarWeight}");
            NextCarMethod();
        }
        private void                        CreateNewEmployeeMethod()
        {
            if (!CheckInputData.CheckNotEmptyString(Login) || !CheckInputData.CheckLatin(Login)
                                                           || CheckInputData.LoginCheck(Login))
            {
                IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Некорректный логин", Title = "Ошибка" });
                return;
            }
            if (!CheckInputData.CheckNotEmptyString(Password) || !CheckInputData.CheckLatin(Password)
                                                              || CheckInputData.PasswordCheck(Password))
            {
                IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Некорректный пароль", Title = "Ошибка" });
                return;
            }
            if (!CheckInputData.CheckNotEmptyString(FullName))
            {
                IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Некорректное ФИО", Title = "Ошибка" });
                return;
            }
            if (!CheckInputData.CheckNotEmptyString(Phone) || !CheckInputData.NumberCheck(Phone))
            {
                IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Некорректный номер телефона", Title = "Ошибка" });
                return;
            }
            if (!CheckInputData.CheckNotEmptyString(Email) || !CheckInputData.CheckLatin(Email)
                                                           || CheckInputData.EmailCheck(Email))
            {
                IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Некорректная эл.почта", Title = "Ошибка" });
                return;
            }
            if (!CheckInputData.CheckNotEmptyString(Position))
            {
                IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Некорректная должность", Title = "Ошибка" });
                return;
            }

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
