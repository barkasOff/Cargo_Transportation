using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.Base;

namespace Cargo_Transportation.ViewModels.UserPageViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string OutgoingIncoming { get; set; }
        public string ProductWeight { get; set; }
        public string Status { get; set; }

        public ProductViewModel(Product product)
        {
            product = new Product(StatusOfProduct.Current)
            {
                Name = "Одежда",
                OutgoingIncoming = true,
                ProductWeight = 300
            };
            Name = product.Name;
            OutgoingIncoming = product.OutgoingIncoming ? "Исходящий" : "Входящий";
            ProductWeight = product.ProductWeight.ToString();
            switch (product.Status)
            {
                case StatusOfProduct.Current:
                    Status = "Current";
                    break;
                case StatusOfProduct.Inpprocessing:
                    Status = "Inpprocessing";
                    break;
                case StatusOfProduct.Completed:
                    Status = "Completed";
                    break;
            }
        }
    }
}
