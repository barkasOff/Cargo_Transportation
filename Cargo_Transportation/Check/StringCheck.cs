using Cargo_Transportation.Interfaces;
using Cargo_Transportation.Models;
using System.Diagnostics;

namespace Cargo_Transportation.Check
{
    public static class                         StringCheck
    {
        public static string                    Convert_Order_Status(StatusOfProduct statusOfProduct)
        {
            switch (statusOfProduct)
            {
                case StatusOfProduct.Current:
                    return ("Current");
                case StatusOfProduct.Completed:
                    return ("Confirm");
                case StatusOfProduct.Inpprocessing:
                    return ("Inprocessing");
                case StatusOfProduct.DispetcherInpprocessing:
                    return ("Inprocessing");
                case StatusOfProduct.HoldUserAccept:
                    return ("Accept");
                case StatusOfProduct.HoldDispetcherToDriverAccept:
                    return ("Orginize");
                case StatusOfProduct.HoldDriverAccept:
                    return ("Take");
                default:
                    Debugger.Break();
                    return ("Error");
            }
        }
        public static ShowVariablesOfDialog     Convert_Order_Status_To_Dialog(StatusOfProduct statusOfProduct)
        {
            switch (statusOfProduct)
            {
                /*case StatusOfProduct.Current:
                    return ("Current");
                case StatusOfProduct.Completed:
                    return ("Confirm");*/
                case StatusOfProduct.Inpprocessing:
                    return (ShowVariablesOfDialog.ShowMessage);
                case StatusOfProduct.DispetcherInpprocessing:
                    return (ShowVariablesOfDialog.ShowOrderProcessing);
                case StatusOfProduct.HoldUserAccept:
                    return (ShowVariablesOfDialog.ShowOrderInformationAfterConfirmation);
                /*case StatusOfProduct.HoldDispetcherToDriverAccept:
                    return ("Orginize");
                case StatusOfProduct.HoldDriverAccept:
                    return ("Take");*/
                default:
                    Debugger.Break();
                    return (ShowVariablesOfDialog.ShowMessage);
            }
        }
    }
}
