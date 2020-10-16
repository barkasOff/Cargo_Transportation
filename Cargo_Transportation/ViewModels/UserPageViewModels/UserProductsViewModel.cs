using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class UserProductsViewModel : BaseViewModel
    {
        public string ProfilePictureRGB { get; set; }
        public string Initials { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }

        public ICommand ShowProductInfoCommand { get; set; }

        public UserProductsViewModel()
        {
            ShowProductInfoCommand = new RelayCommand(ShowProductInfoMethod);
        }

        private void ShowProductInfoMethod()
        {
            if (IoC.Application.OrderProcessingOrInformation == ShowVariablesOfDialog.ShowOrderProcessing)
            {
                IoC.UI.ShowOrderProcessing(new MessageBoxDialogViewModel()
                {
                    Title = "Order Processing",
                });
            }
            else if (IoC.Application.OrderProcessingOrInformation == ShowVariablesOfDialog.ShowOrderInformationAfterConfirmation)
            {
                IoC.UI.ShowOrderInformationAfterConfirmation(new MessageBoxDialogViewModel()
                {
                    Title = "Accepted Order Information",
                });
            }
            else if (IoC.Application.OrderProcessingOrInformation == ShowVariablesOfDialog.ShowMessage)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel()
                {
                    Title = "Order Information",
                });
            }
            else if (IoC.Application.OrderProcessingOrInformation == ShowVariablesOfDialog.OrderToTheDriver)
            {
                IoC.UI.ShowOrderToTheDriver(new MessageBoxDialogViewModel()
                {
                    Title = "Order to the driver",
                });
            }
        }
    }
}
