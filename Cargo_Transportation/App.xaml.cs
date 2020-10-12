using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog.Ioc;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using System.Threading.Tasks;
using System.Windows;

namespace Cargo_Transportation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await ApplicationSetup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private async Task ApplicationSetup()
        {
            IoC.Setup();
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            await Task.Run(() => WorkWithDB.Get_Users());
        }
    }
}
