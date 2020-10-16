using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cargo_Transportation.DBProvider
{
    public static class                     WorkWithDB
    {
        public static void                  Get_Users()
        {
            using (var context = new ApplicationDbContext())
            {
                var clients = context.Clients.Include(o => o.Products).ToList();

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
        public static void                  Get_Cars()
        {
            using (var context = new ApplicationDbContext())
                IoC.Application_Work.All_Cars = context.Cars.ToList();
        }
        public static void                  Get_Routes()
        {
            using (var context = new ApplicationDbContext())
                IoC.Application_Work.All_Routes = context.Routes.ToList();
        }
        public static void                  Get_Products()
        {
            using (var context = new ApplicationDbContext())
                IoC.Application_Work.All_Orders = context.Products.ToList();
        }
        public static async void            Set_User_Async(User user)
        {
            IoC.Application_Work.All_Users.Add(user);
            using (var context = new ApplicationDbContext())
            {
                if (user is Client)
                    await context.Clients.AddAsync(user as Client);
                else
                    await context.Employees.AddAsync(user as Employee);
                await context.SaveChangesAsync();
            }
        }
        public static async void            Set_Car_Async(Car car)
        {
            IoC.Application_Work.All_Cars.Add(car);
            using (var context = new ApplicationDbContext())
            {
                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }
        }
        public static async void            Set_Routes_Async(Route route)
        {
            IoC.Application_Work.All_Routes.Add(route);
            using (var context = new ApplicationDbContext())
            {
                await context.Routes.AddAsync(route);
                await context.SaveChangesAsync();
            }
        }
        public static async void            Set_Product_Async(Product product)
        {
            IoC.Application_Work.All_Orders.Add(product);
            (IoC.Application_Work.Current_User as Client).Products.Add(product);
            using (var context = new ApplicationDbContext())
            {
                if (IoC.Application_Work.Current_User is Client)
                {
                    var client = context.Clients.First(u => u.Login == IoC.Application_Work.Current_User.Login);
                    client.Products.Add(product);
                    context.Clients.Update(client);
                }
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
        }
    }
}
