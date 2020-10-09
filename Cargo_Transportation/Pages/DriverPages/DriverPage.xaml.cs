using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.ViewModels.DriverViewModels;
using System.ComponentModel;

namespace Cargo_Transportation.Pages.DriverPages
{
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : BasePage
    {
        public DriverPage()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                DataContext = new DriverViewModel();
            else
                DataContext = IoC.DriverView;
        }
    }
}
