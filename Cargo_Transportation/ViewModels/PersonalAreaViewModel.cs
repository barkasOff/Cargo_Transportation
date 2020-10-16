using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels
{
    public class            PersonalAreaViewModel : BaseViewModel
    {
        public bool         ShowPersonalArea { get; set; } = true;
        public string       FullName { get; set; }
        public string       Email { get; set; }
        public string       PhoneNumber { get; set; }
        public string       Position { get; set; }
        public string       Task { get; set; }

        public PersonalAreaViewModel()
        {
            Update_Personal_Area();
        }

        public void         Update_Personal_Area()
        {
            FullName = (IoC.Application_Work.Current_User as Employee)?.FullName;
            Email = (IoC.Application_Work.Current_User as Employee)?.Email;
            PhoneNumber = (IoC.Application_Work.Current_User as Employee)?.PhoneNumber;
            Position = (IoC.Application_Work.Current_User as Employee)?.Position;
            Task = (IoC.Application_Work.Current_User as Employee)?.Task;
        }
    }
}
