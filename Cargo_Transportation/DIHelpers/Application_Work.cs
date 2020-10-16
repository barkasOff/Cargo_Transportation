using Cargo_Transportation.Models;
using System.Collections.Generic;

namespace Cargo_Transportation.DIHelpers
{
    public class                Application_Work
    {
        public User             Current_User { get; set; }
        public List<User>       All_Users { get; set; }
        public List<Product>    All_Orders { get; set; }
        public List<Car>        All_Cars { get; set; }
        public List<Route>      All_Routes { get; set; }

        public Application_Work()
        {
            All_Users = new List<User>();
            All_Orders = new List<Product>();
            All_Cars = new List<Car>();
            All_Orders = new List<Product>();
            All_Routes = new List<Route>();
        }
    }
}
