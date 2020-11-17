using Cargo_Transportation.Check;
using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.AdminViewModels
{
	public class			CreateNewCarViewModel : BaseViewModel
    {
		public string		CarNumber { get; set; }
		public string		CarBrand { get; set; }
		public string		CarWeight { get; set; }
        public bool			ShowNewCar { get; set; }
		public string		LifCap { get; set; }

		public ICommand		NewCarCommand { get; set; }

		public CreateNewCarViewModel()
		{
			NewCarCommand = new RelayCommand(CreateNewCarMethod);
		}

		private bool CheckCarNumber()
		{
			if (CarNumber.Length != 6)
				throw new Exception("There is symbols for number?!");
			return (CheckInputData.IsAlpha(CarNumber[0]) && CheckInputData.IsNumber(CarNumber[1]) &&
					CheckInputData.IsNumber(CarNumber[2]) && CheckInputData.IsNumber(CarNumber[3]) &&
					CheckInputData.IsAlpha(CarNumber[4]) && CheckInputData.IsAlpha(CarNumber[5]));
		}
		private void CreateNewCarMethod()
		{
			try
			{
				var carWeight = int.Parse(this.CarWeight);
				var lifCap = int.Parse(this.LifCap);

				if (lifCap > carWeight / 2 && carWeight > 2000)
					throw new Exception("Too match LiftingCapacity of the car!!");
				else if (CarNumber == string.Empty || LifCap == string.Empty ||
						 CarWeight == string.Empty || CarBrand == string.Empty)
					throw new Exception("Fill in all cells!!");
				else if (!CheckCarNumber())
					throw new Exception("Incorrect car number!!");
				var car = new Car
				{
					CarBrand = this.CarBrand,
					CarNumber = this.CarNumber,
					CarWeight = carWeight,
					LiftingCapacity = lifCap
				};
				foreach (var c in IoC.Application_Work.All_Cars)
					if (c.CarNumber == car.CarNumber)
						throw new Exception("There is a car with the same number!!");
				WorkWithDB.Set_Car_Async(car);
				CarBrand = "";
				CarNumber = "";
				CarWeight = "";
				LifCap = "";
				IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = "Car was added", Title = "Congratulations" });
			}
			catch (Exception ex)
			{
				IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel { Message = ex.Message, Title = "Error" });
			}
		}
	}
}
