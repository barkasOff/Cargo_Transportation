using Cargo_Transportation.Models;

namespace Cargo_Transportation.Dialog
{
    public class MessageBoxDialogViewModel : BaseDiallogViewModel
    {
        public string Message { get; set; } = "Hello!";
        public string OkText { get; set; } = "OK";
    }
}
