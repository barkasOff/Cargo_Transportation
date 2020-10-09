using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels.DriverViewModels
{
    public class DriverPAViewModel : BaseViewModel
    {
        public bool ShowDriverPersonalArea { get; set; } = true;
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Task { get; set; }

        // TODO: normal data
        public DriverPAViewModel()
        {
            FullName = "Ibragimova Kamila XZ";
            Email = "Ibragimova Kamila XZ";
            PhoneNumber = "XZ";
            Position = "LOX";
            Task = "Yborka";
        }
    }
}
