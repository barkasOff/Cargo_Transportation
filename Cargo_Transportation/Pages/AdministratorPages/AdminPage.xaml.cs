using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.ViewModels.AdminViewModels;
using System.ComponentModel;

namespace Cargo_Transportation.Pages.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : BasePage
    {
        public AdminPage()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                DataContext = new AdminViewModel();
            else
                DataContext = IoC.AdminView;
        }
    }
}
