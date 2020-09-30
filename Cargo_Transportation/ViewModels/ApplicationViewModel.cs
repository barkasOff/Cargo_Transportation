using Cargo_Transportation.Pages;
using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
