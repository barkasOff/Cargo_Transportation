using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System.Linq;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.DriverViewModels
{
    public class            CarViewModel : BaseViewModel
    {
        public string       CarProfilePictureRGB { get; set; }
        public string       CarInitials { get; set; }
        public string       CarBrand { get; set; }
        public string       CarDriver { get; set; }
        public string       StatusColor { get; set; }
        public string       CarStatus { get; set; }
        public string       SelectColor { get; set; } = "7d7d7d";
        public string       CarLiftingCapacity { get; set; }
        public Car          Car { get; set; }
        public Product      Product { get; set; }

        public ICommand     SelectCarCommand { get; set; }

        public CarViewModel()
        {
            SelectCarCommand = new RelayCommand(() => SelectColor = "8a8a8a");
        }
    }
}
