using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels.DispatcherViewModels
{
    public class DispatcherPAViewModel : BaseViewModel
    {
        public bool ShowDispatcherPersonalArea { get; set; } = true;
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Task { get; set; }

        // TODO: normal data
        public DispatcherPAViewModel()
        {
            FullName = "Ibragimova Kamila XZ";
            Email = "Ibragimova Kamila XZ";
            PhoneNumber = "XZ";
            Position = "LOX";
            Task = "Yborka";
        }
    }
}
