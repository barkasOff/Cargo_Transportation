using Cargo_Transportation.ViewModels.Base;
using System;

namespace Cargo_Transportation.ViewModels.Order
{
    public class OrderDialogViewModel : BaseViewModel
    {
        public string       OrderName { get; set; }
        public string       OrderWeight { get; set; }
        public string       From { get; set; }
        public string       To { get; set; }
        public string       DeliveryDate { get; set; }
    }
}
