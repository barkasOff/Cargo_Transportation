using Cargo_Transportation.IoC;

namespace Cargo_Transportation.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => IoC.IoC.Application;
    }
}
