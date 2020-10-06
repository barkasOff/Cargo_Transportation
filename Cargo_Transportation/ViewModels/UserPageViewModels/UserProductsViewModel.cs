using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
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
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel(new Product(StatusOfProduct.Current))
            {
                Title = "ProductName",
            });
        }
    }
}
