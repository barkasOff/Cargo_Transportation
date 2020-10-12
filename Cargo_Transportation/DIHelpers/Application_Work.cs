using Cargo_Transportation.Models;
using System.Collections.Generic;

namespace Cargo_Transportation.DIHelpers
{
    public class Application_Work
    {
        public User Current_User { get; set; }
        public List<User> All_Users { get; set; }

        public Application_Work()
        {
            All_Users = new List<User>();
        }
    }
}
