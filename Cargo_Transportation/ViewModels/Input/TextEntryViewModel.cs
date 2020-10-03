using Cargo_Transportation.ViewModels.Base;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.Input
{
    public class            TextEntryViewModel : BaseViewModel
    {
        public string       Label { get; set; }
        public string       OriginalText { get; set; }
        public string       EditedText { get; set; }
        public bool         Editing { get; set; }
        public int          MaxLength { get; set; }

        public ICommand     EditCommand { get; set; }
        public ICommand     CancelCommand { get; set; }
        public ICommand     SaveCommand { get; set; }

        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(EditMethod);
            CancelCommand = new RelayCommand(CancelMethod);
            SaveCommand = new RelayCommand(SaveMethod);
        }

        private void        SaveMethod()
        {
            OriginalText = EditedText;
            Editing = false;
        }
        private void        CancelMethod()
        {
            Editing = false;
        }
        private void        EditMethod()
        {
            EditedText = OriginalText;
            Editing = true;
        }
    }
}
