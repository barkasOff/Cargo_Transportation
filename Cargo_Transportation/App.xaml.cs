using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog.Ioc;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Cargo_Transportation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class            App : Application
    {
        protected override void     OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();
            (new Thread(new ThreadStart(Db_Work))).Start();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void                ApplicationSetup()
        {
            IoC.Setup();
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
        private void                Db_Work()
        {
            WorkWithDB.Get_Users();
            WorkWithDB.Get_Products();
            WorkWithDB.Get_Cars();
            WorkWithDB.Get_Routes();
        }
    }
}
