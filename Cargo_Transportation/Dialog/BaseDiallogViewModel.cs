using Cargo_Transportation.Models;
using Cargo_Transportation.ViewModels.UserPageViewModels;

namespace Cargo_Transportation.Dialog
{
    public class BaseDiallogViewModel : ProductViewModel
    {
        public string Title { get; set; }
        public BaseDiallogViewModel(Product product) : base(product)
        { }
    }
}
