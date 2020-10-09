using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels;
using Cargo_Transportation.ViewModels.DispatcherViewModels;
using Cargo_Transportation.ViewModels.DriverViewModels;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using Ninject;

namespace Cargo_Transportation.DIHelpers
{
    public static class IoC
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();
        public static ApplicationViewModel Application => Get<ApplicationViewModel>();
        public static UserPageViewModels UserView => Get<UserPageViewModels>();
        public static DispatcherViewModels DispatcherView => Get<DispatcherViewModels>();
        public static DriverViewModel DriverView => Get<DriverViewModel>();
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
        }
        public static T Get<T>() =>
            Kernel.Get<T>();
    }
}
