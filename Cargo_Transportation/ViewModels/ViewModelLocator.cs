using Cargo_Transportation.DIHelpers;

namespace Cargo_Transportation.ViewModels
{
    public class                            ViewModelLocator
    {
        public static ViewModelLocator      Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel  ApplicationViewModel => IoC.Application;
    }
}
