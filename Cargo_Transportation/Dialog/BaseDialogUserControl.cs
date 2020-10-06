using Cargo_Transportation.ViewModels;
using Cargo_Transportation.ViewModels.Base;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cargo_Transportation.Dialog
{
    public class BaseDialogUserControl : UserControl
    {
        private DialogWindow _dialogWindow;

        public int MinimHeight { get; set; } = 100;
        public int MinimWidth { get; set; } = 250;
        public int TitleHeight { get; set; } = 15;
        public string Title { get; set; }

        public ICommand CloseCommand { get; private set; }

        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                _dialogWindow = new DialogWindow();
                _dialogWindow.ViewModel = new DialogWindowViewModel(_dialogWindow);

                CloseCommand = new RelayCommand(() => _dialogWindow.Close());
            }
        }

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDiallogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    _dialogWindow.ViewModel.MinHeight = MinimHeight;
                    _dialogWindow.ViewModel.MinWidth = MinimWidth;
                    _dialogWindow.ViewModel.TitleHeight = TitleHeight;
                    _dialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    _dialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;

                    _dialogWindow.ShowDialog();
                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }
    }
}
