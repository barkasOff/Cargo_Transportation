using Cargo_Transportation.ViewModels.Base;
using System;

namespace Cargo_Transportation.ViewModels.Order
{
    public class OrderDialogViewModel : BaseViewModel
    {
        public string       OrderName { get; set; } = "Empty";
        public string       OrderWeight { get; set; } = "Empty";
        public string       From { get; set; } = "Empty";
        public string       To { get; set; } = "Empty";
        public string       DeliveryDate { get; set; } = "Empty";
        public string       DispetcherName { get; set; } = "Empty";
        public string       DriverName { get; set; } = "Empty";
        public string       CarBrand { get; set; } = "Empty";
        public string       CarNumber { get; set; } = "Empty";
        public string       AdoptionDate { get; set; } = "Empty";
    }
}
