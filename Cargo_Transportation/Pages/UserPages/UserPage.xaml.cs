using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using System.ComponentModel;

namespace Cargo_Transportation.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : BasePage
    {
        public UserPage()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                // Create new instance of settings view model
                DataContext = new UserPageViewModels();
            else
                DataContext = IoC.UserView;
        }
    }
}
