using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cargo_Transportation.DBProvider
{
    public static class                     WorkWithDB
    {
        public static void                  Get_Users()
        {
            using (var context = new ApplicationDbContext())
            {
                var clients = context.Clients.ToList();

                foreach (var client in clients)
                    IoC.Application_Work.All_Users.Add(client);
            }
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees.ToList();

                foreach (var employee in employees)
                    IoC.Application_Work.All_Users.Add(employee);
            }
        }
        public static List<Car>             Get_Cars()
        {
            using (var context = new ApplicationDbContext())
                return (context.Cars.ToList());
        }
        public static List<Route>           Get_Routes()
        {
            using (var context = new ApplicationDbContext())
                return (context.Routes.ToList());
        }
        public static List<Product>         Get_Products()
        {
            using (var context = new ApplicationDbContext())
                return (context.Products.ToList());
        }
    }
}
