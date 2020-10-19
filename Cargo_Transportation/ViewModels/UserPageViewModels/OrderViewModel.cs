using Cargo_Transportation.Check;
using Cargo_Transportation.DBProvider;
using Cargo_Transportation.Dialog;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class                OrderViewModel : BaseViewModel
    {
        private int             _orderWeight = 0;
        public string           OrderName { get; set; }
        public string           OrderWeight { get; set; }
        public string           InputOrOutput { get; set; }
        public string           OrderFrom { get; set; }
        public string           OrderTo { get; set; }
        public DateTime         DeliveryDate { get; set; }
        public bool             ShowDoTheOrder { get; set; }

        public ICommand         CreateNewOrderCommand { get; set; }

        public OrderViewModel()
        {
            CreateNewOrderCommand = new RelayCommand(CreateNewOrderMethodAsync);
            DeliveryDate = DateTime.Now;
        }

        private bool            Check_Input_Data()
        {
            if (InputOrOutput != "В" && InputOrOutput != "И" ||
                OrderName == string.Empty || !int.TryParse(OrderWeight, out _orderWeight) ||
                OrderFrom == string.Empty || OrderTo == string.Empty)
                return (false);
            return (true);
        }
        private Product         Create_New_Order() => new Product(StatusOfProduct.Inpprocessing)
        {
            Name = OrderName,
            OutgoingIncoming = InputOrOutput == "И",
            ProductWeight = _orderWeight,            
        };
        private Route           Create_New_Route(Product product) => new Route(DeliveryDate, DateTime.Now)
        {
            From = OrderFrom,
            To = OrderTo,
            Product = product,
        };
        private async void      CreateNewOrderMethodAsync()
        {
            if (!Check_Input_Data())
            {
                await IoC.UI.CommunicationDialog(new MessageBoxDialogViewModel() { Title = "Error", Message = "Uncorrect input data!!" });
                return;
            }
            var product = Create_New_Order();
            WorkWithDB.Set_Routes_Async(Create_New_Route(product));
            // TODO: Add to db
            var userPVM = new UserProductsViewModel
            {
                Initials = "CL",
                ProfilePictureRGB = "89ccb7",
                Status = StringCheck.Convert_Order_Status(product.Status),
                UserName = (IoC.Application_Work.Current_User as Client).Login,
                StatusColor = product.Status == StatusOfProduct.Completed ? "00c541" : product.Status == StatusOfProduct.Current ? "ff4747" : "0080ff",
                ProductName = product.Name
            };
            if (product.OutgoingIncoming)
                IoC.UserView.InboxOrders.Add(userPVM);
            else
                IoC.UserView.OutboxOrders.Add(userPVM);
            IoC.DispatcherView.Add_New_Order(userPVM);
            Clear_Data();
            IoC.UserView.Set_Orders();
        }
        private void            Clear_Data()
        {
            OrderName = "";
            OrderWeight = "";
            InputOrOutput = "";
            OrderFrom = "";
            OrderTo = "";
            DeliveryDate = DateTime.Now;
        }
    }
}
