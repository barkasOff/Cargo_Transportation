using Cargo_Transportation.Dialog;
using System.Threading.Tasks;

namespace Cargo_Transportation.Interfaces
{
    public interface IUIManager
    {
        Task AppointDriverCarDialog(DialogWithOrderInfoViewModel viewModel);
        Task CommunicationDialog(MessageBoxDialogViewModel viewModel);
        Task EmployeeInfo(EmployeeDialoViewModel viewModel);
        Task ShowMessage(DialogWithOrderInfoViewModel viewModel);
        Task ChoiseShowMessage(DialogWithOrderInfoViewModel viewModel);
        Task ShowOrderProcessing(DialogWithOrderInfoViewModel viewModel);
        Task ShowOrderInformationAfterConfirmation(MessageBoxDialogViewModel viewModel);
        Task ShowUserAcceptOrder(DialogWithOrderInfoViewModel viewModel);
        Task ShowOrderToTheDriver(MessageBoxDialogViewModel viewModel);
    }
}
