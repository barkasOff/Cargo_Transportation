using Cargo_Transportation.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.Dialog
{
    public class            DispetcherOrderProcessingViewModel : BaseDiallogViewModel
    {
        private int _priceOneCar = 0;
        private int _numberCars = 0;
        private int _deliveryCost = 0;

        public string       PriceOneCar { get; set; }
        public string       NumberCars { get; set; }
        public string       DeliveryCost { get; set; }

        public ICommand     SendCommand { get; set; }
        public ICommand     CancelCommand { get; set; }

        public DispetcherOrderProcessingViewModel()
        {
            SendCommand = new RelayCommand(SendMethod);
            CancelCommand = new RelayCommand(CancelMethod);
        }

        private void        CancelMethod()
        {
            throw new NotImplementedException();
        }
        private void        SendMethod()
        {
            if (!int.TryParse(PriceOneCar, out _priceOneCar) ||
                !int.TryParse(NumberCars, out _numberCars) ||
                !int.TryParse(DeliveryCost, out _deliveryCost))
                return;
        }
    }
}
