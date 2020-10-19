using Cargo_Transportation.Check;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Security;
using Cargo_Transportation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.LogReg
{
    public class                LoginViewModel : BaseViewModel
    {
        public string           Login { get; set; }

        public ICommand         LoginCommand { get; set; }
        public ICommand         CancelCommand { get; set; }
        public ICommand         GOTORegisterPageCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommandParameter(async (parameter) => await LoginMethodAsync(parameter));
            CancelCommand = new RelayCommand(CancelMethod);
            GOTORegisterPageCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Register));
        }

        private async Task      LoginMethodAsync(object parameter)
        {
            string password = (parameter as IHavePassword)?.SecurePassword?.Unsecure();
            switch (LoginRegisterCheck.Which_User(Login, password))
            {
                case AplicationUser.User:
                    IoC.UserView.PersonalAreaVM.Update_User_PA();
                    IoC.Application.GoToPage(ApplicationPage.UserPage);
                    IoC.UserView.Set_Orders();
                    break;
                case AplicationUser.Dispatcher:
                    IoC.DispatcherView.EmployeePAViewModel.Update_Personal_Area();
                    IoC.Application.GoToPage(ApplicationPage.DispatcherPage);
                    IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.ShowOrderProcessing;
                    IoC.DispatcherView.Set_Orders();
                    break;
                case AplicationUser.Driver:
                    IoC.DriverView.EmployeePAViewModel.Update_Personal_Area();
                    IoC.Application.GoToPage(ApplicationPage.Driver);
                    IoC.Application.OrderProcessingOrInformation = ShowVariablesOfDialog.OrderToTheDriver;
                    IoC.DriverView.Assigned_Order();
                    break;
                default:
                    await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Title = "Error", Message = "Who are you?" });
                    break;
            }
        }
        private void            CancelMethod()
        {
            Login = "";
        }
    }
}
