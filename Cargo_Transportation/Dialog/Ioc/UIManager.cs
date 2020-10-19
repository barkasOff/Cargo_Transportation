using Cargo_Transportation.Controls.DispatcherPageControls;
using Cargo_Transportation.Dialog.Controls;
using Cargo_Transportation.Interfaces;
using System.Threading.Tasks;

namespace Cargo_Transportation.Dialog.Ioc
{
    public class UIManager : IUIManager
    {
        public Task CommunicationDialog(MessageBoxDialogViewModel viewModel) =>
            new UserDialogControl().ShowDialog(viewModel);
        public Task AppointDriverCarDialog(DialogWithOrderInfoViewModel viewModel) =>
            new AppointDriverCar().ShowDialog(viewModel);
        public Task ShowMessage(DialogWithOrderInfoViewModel viewModel) =>
            new OrderInformationControl().ShowDialog(viewModel);
        public Task ChoiseShowMessage(DialogWithOrderInfoViewModel viewModel) =>
            new ShowProductProfileDialogControl().ShowDialog(viewModel);
        public Task ShowOrderProcessing(DialogWithOrderInfoViewModel viewModel) =>
            new DispetcherOrderProcessing().ShowDialog(viewModel);
        public Task ShowOrderInformationAfterConfirmation(MessageBoxDialogViewModel viewModel) =>
            new OrderInformationAfterConfirmation().ShowDialog(viewModel);
        public Task ShowUserAcceptOrder(DialogWithOrderInfoViewModel viewModel) =>
            new UserAcceptOrder().ShowDialog(viewModel);
        public Task ShowOrderToTheDriver(MessageBoxDialogViewModel viewModel) =>
            new OrderToTheDriver().ShowDialog(viewModel);
    }
}
