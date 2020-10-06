using Cargo_Transportation.Dialog.Controls;
using Cargo_Transportation.Interfaces;
using System.Threading.Tasks;

namespace Cargo_Transportation.Dialog.Ioc
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel) =>
            new ShowProductProfileDialogControl().ShowDialog(viewModel);

        public Task YesNoShowMessage(MessageBoxDialogViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
