using Cargo_Transportation.ViewModels;
using System.Windows;

namespace Cargo_Transportation
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class                DialogWindow : Window
    {
        private DialogWindowViewModel   _viewModel;
        public DialogWindowViewModel    ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
