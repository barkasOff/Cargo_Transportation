using Cargo_Transportation.Interfaces;
using Cargo_Transportation.ViewModels;
using Cargo_Transportation.ViewModels.UserPageViewModels;
using Ninject;

namespace Cargo_Transportation.DIHelpers
{
    public static class IoC
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();
        public static ApplicationViewModel Application => Get<ApplicationViewModel>();
        public static UserPageViewModels UserView => Get<UserPageViewModels>();
        public static IUIManager UI => Get<IUIManager>();

        public static void Setup()
        {
            BindViewModels();
        }
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<UserPageViewModels>().ToConstant(new UserPageViewModels());
        }
        public static T Get<T>() =>
            Kernel.Get<T>();
    }
}
