using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels;
using Cargo_Transportation.ViewModels.DispatcherViewModels;
using Cargo_Transportation.ViewModels.DriverViewModels;
using Cargo_Transportation.ViewModels.LogReg;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using Ninject;

namespace Cargo_Transportation.DIHelpers
{
    public static class IoC
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();
        public static Application_Work Application_Work => Get<Application_Work>();
        public static ApplicationViewModel Application => Get<ApplicationViewModel>();
        public static LoginViewModel LoginView => Get<LoginViewModel>();
        public static RegisterViewModel RegisterView => Get<RegisterViewModel>();
        public static UserPageViewModels UserView => Get<UserPageViewModels>();
        public static DispatcherViewModels DispatcherView => Get<DispatcherViewModels>();
        public static DriverViewModel DriverView => Get<DriverViewModel>();
        public static EmployeeViewModel EmployeeView => Get<EmployeeViewModel>();
        public static IUIManager UI => Get<IUIManager>();

        public static void Setup()
        {
            BindViewModels();
        }
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<UserPageViewModels>().ToConstant(new UserPageViewModels());
            Kernel.Bind<DispatcherViewModels>().ToConstant(new DispatcherViewModels());
            Kernel.Bind<DriverViewModel>().ToConstant(new DriverViewModel());
            Kernel.Bind<EmployeeViewModel>().ToConstant(new EmployeeViewModel());
            Kernel.Bind<Application_Work>().ToConstant(new Application_Work());
        }
        public static T Get<T>() =>
            Kernel.Get<T>();
    }
}
