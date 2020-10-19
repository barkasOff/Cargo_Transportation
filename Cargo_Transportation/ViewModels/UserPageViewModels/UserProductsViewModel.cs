using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.DriverViewModels;
using Cargo_Transportation.ViewModels.Order;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class                                    UserProductsViewModel : BaseViewModel
    {
        public string                               ProfilePictureRGB { get; set; }
        public string                               Initials { get; set; }
        public string                               UserName { get; set; }
        public string                               ProductName { get; set; }
        public string                               Status { get; set; }
        public string                               StatusColor { get; set; }
        public Product                              Product { get; set; }
        public OrderDialogViewModel                 OrderDialogViewModel { get; set; }
        public ShowVariablesOfDialog                ShowVariablesOfDialog { get; set; } = ShowVariablesOfDialog.ShowMessage;

        public ICommand                             ShowProductInfoCommand { get; set; }

        public UserProductsViewModel()
        {
            ShowProductInfoCommand = new RelayCommand(ShowProductInfoMethod);
        }

        private void                                ShowMessageMethod()
        {
            if (Product.Status == StatusOfProduct.Completed || 
                Product.Status == StatusOfProduct.Current ||
                Product.Status == StatusOfProduct.HoldDriverAccept ||
                (Product.Status == StatusOfProduct.HoldDispetcherToDriverAccept && IoC.Application_Work.Current_User is Client))
                IoC.UI.ShowMessage(new DialogWithOrderInfoViewModel()
                {
                    Title = "Order Information",
                    Product = this.Product,
                    Id = this.Product.Id.ToString(),
                    OrderDialogViewModel = this.OrderDialogViewModel,
                });
            else if (Product.Status == StatusOfProduct.HoldDispetcherToDriverAccept)
            {
                IoC.UI.AppointDriverCarDialog(new DialogWithOrderInfoViewModel()
                {
                    Title = "Order To Driver Sending",
                    Product = this.Product,
                    Id = this.Product.Id.ToString(),
                    OrderDialogViewModel = this.OrderDialogViewModel,
                });
            }
            else
                IoC.UI.ChoiseShowMessage(new DialogWithOrderInfoViewModel()
                {
                    Title = "Order Information",
                    Product = this.Product,
                    Id = this.Product.Id.ToString(),
                    OrderDialogViewModel = this.OrderDialogViewModel,
                });
        }
        private void                                ShowOrderInformationAfterConfirmationMethod()
        {
            if (Product.Status == StatusOfProduct.HoldUserAccept)
            {
                IoC.UI.ShowUserAcceptOrder(new DialogWithOrderInfoViewModel()
                {
                    Title = "Accepted Order",
                    Product = this.Product,
                    Id = this.Product.Id.ToString(),
                    OrderDialogViewModel = this.OrderDialogViewModel,
                });
            }
            else
            {
                IoC.UI.ShowOrderInformationAfterConfirmation(new MessageBoxDialogViewModel()
                {
                    Title = "Confirm Order",
                });
            }
        }
        private void                                OrderToTheDriverMethod()
        {
            IoC.UI.ShowOrderToTheDriver(new MessageBoxDialogViewModel()
            {
                Title = "Order to the driver",
            });
        }
        private void                                ShowOrderProcessingMethod()
        {
            IoC.UI.ShowOrderProcessing(new DialogWithOrderInfoViewModel()
            {
                Title = "Order Processing",
                Product = this.Product,
                Id = this.Product.Id.ToString(),
                OrderDialogViewModel = this.OrderDialogViewModel
            });
        }
        private void                                ShowProductInfoMethod()
        {
            if (ShowVariablesOfDialog == ShowVariablesOfDialog.ShowOrderProcessing)
                ShowOrderProcessingMethod();
            else if (ShowVariablesOfDialog == ShowVariablesOfDialog.ShowOrderInformationAfterConfirmation)
                ShowOrderInformationAfterConfirmationMethod();
            else if (ShowVariablesOfDialog == ShowVariablesOfDialog.ShowMessage)
                ShowMessageMethod();
            else if (ShowVariablesOfDialog == ShowVariablesOfDialog.OrderToTheDriver)
                OrderToTheDriverMethod();
        }
    }
}
