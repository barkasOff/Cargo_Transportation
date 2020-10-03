using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.ViewModels;
using System.Windows;

namespace Cargo_Transportation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }

        private void Window_Activated(object sender, System.EventArgs e) =>
            IoC.Application.DimmebleOverlayVisible = false;

        private void Window_Deactivated(object sender, System.EventArgs e) =>
            IoC.Application.DimmebleOverlayVisible = true;
    }
}
