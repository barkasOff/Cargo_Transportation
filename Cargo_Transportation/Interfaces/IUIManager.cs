using Cargo_Transportation.Dialog;
using System.Threading.Tasks;

namespace Cargo_Transportation.Interfaces
{
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
        Task YesNoShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
