using System.Windows;
using System.Windows.Controls;

namespace Cargo_Transportation.ViewModels
{
    public class DialogWindowViewModel : WindowViewModel
    {
        public string Title { get; set; }
        public Control Content { get; set; }

        public DialogWindowViewModel(Window window) : base(window)
        {
            MinWidth = 250;
            MinHeight = 100;
        }
    }
}
