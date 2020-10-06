using Cargo_Transportation.Dialog.Ioc;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using System.Windows;

namespace Cargo_Transportation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}
