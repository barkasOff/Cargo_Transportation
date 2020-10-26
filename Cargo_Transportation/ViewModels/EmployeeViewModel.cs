using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.ViewModels.Base;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels
{
    public class                                            EmployeeViewModel : BaseViewModel
    {
        public PersonalAreaViewModel                        EmployeePAViewModel { get; set; }
        public ObservableCollection<UserProductsViewModel>  Orders { get; set; }
        public bool                                         ShowAllOrders { get; set; }

        public ICommand                                     ExitCommand { get; set; }

        public EmployeeViewModel()
        {
            EmployeePAViewModel = new PersonalAreaViewModel();
            ExitCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Login));
        }
    }
}
