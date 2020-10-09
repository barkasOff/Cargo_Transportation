using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.ViewModels.DispatcherViewModels;
using System.ComponentModel;

namespace Cargo_Transportation.Pages.DispatcherPages
{
    /// <summary>
    /// Логика взаимодействия для DispatcherPage.xaml
    /// </summary>
    public partial class DispatcherPage : BasePage
    {
        public DispatcherPage()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                DataContext = new DispatcherViewModels();
            else
                DataContext = IoC.DispatcherView;
        }
    }
}
