using Cargo_Transportation.ViewModels;
using Ninject;

namespace Cargo_Transportation.IoC
{
    public static class IoC
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();
        public static ApplicationViewModel Application => Get<ApplicationViewModel>();

        public static void Setup()
        {
            BindViewModels();
        }
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
        public static T Get<T>() =>
            Kernel.Get<T>();
    }
}
