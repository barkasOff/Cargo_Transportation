using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        public bool DimmebleOverlayVisible { get; set; }
        public ShowVariablesOfDialog OrderProcessingOrInformation { get; set; } = ShowVariablesOfDialog.ShowMessage;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
