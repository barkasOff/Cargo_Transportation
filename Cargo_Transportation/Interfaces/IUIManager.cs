using Cargo_Transportation.Dialog;
using System.Threading.Tasks;

namespace Cargo_Transportation.Interfaces
{
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
        Task ShowOrderProcessing(MessageBoxDialogViewModel viewModel);
        Task ShowOrderInformationAfterConfirmation(MessageBoxDialogViewModel viewModel);
        Task ShowOrderToTheDriver(MessageBoxDialogViewModel viewModel);
    }
}
