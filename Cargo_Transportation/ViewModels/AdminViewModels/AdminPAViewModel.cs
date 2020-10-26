using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels.AdminViewModels
{
    public class        AdminPAViewModel : BaseViewModel
    {
        public string   FullName { get; set; }
        public string   PhoneNumber { get; set; }
        public string   Email { get; set; }
        public string   Position { get; set; }
        public bool     ShowPA { get; set; } = true;
    }
}
