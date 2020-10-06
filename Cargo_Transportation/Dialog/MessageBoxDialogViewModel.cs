using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.UserPageViewModels;

namespace Cargo_Transportation.Dialog
{
    public class MessageBoxDialogViewModel : BaseDiallogViewModel
    {
        public string Message { get; set; } = "Hello!";
        public string OkText { get; set; } = "OK";

        public MessageBoxDialogViewModel(Product product) : base(product)
        { }
    }
}
