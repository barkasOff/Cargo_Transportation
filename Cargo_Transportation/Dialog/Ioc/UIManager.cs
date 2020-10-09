using Cargo_Transportation.Controls.DispatcherPageControls;
using Cargo_Transportation.Dialog.Controls;
using Cargo_Transportation.Interfaces;
using System.Threading.Tasks;

namespace Cargo_Transportation.Dialog.Ioc
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel) =>
            new ShowProductProfileDialogControl().ShowDialog(viewModel);
        public Task ShowOrderProcessing(MessageBoxDialogViewModel viewModel) =>
            new DispetcherOrderProcessing().ShowDialog(viewModel);
        public Task ShowOrderInformationAfterConfirmation(MessageBoxDialogViewModel viewModel) =>
            new OrderInformationAfterConfirmation().ShowDialog(viewModel);
        public Task ShowOrderToTheDriver(MessageBoxDialogViewModel viewModel) =>
            new OrderToTheDriver().ShowDialog(viewModel);
    }
}
