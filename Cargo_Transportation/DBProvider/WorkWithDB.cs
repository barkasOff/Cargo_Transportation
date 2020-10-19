using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo_Transportation.DBProvider
{
    public static class                     WorkWithDB
    {
        public static void                  Get_Data()
        {
            using var context = new ApplicationDbContext();
            var clients = context.Clients.Include(o => o.Products).ToList();
            var employees = context.Employees.ToList();
            var cars = context.Cars.Include(c => c.CurrentRoute)
                                                        .Include(c => c.CurrentDriver)
                                                        .Include(c => c.Drivers)
                                                        .Include(c => c.Routes).ToList();
            var routes = context.Routes.Include(r => r.Product).ToList();
            var products = context.Products.ToList();

            foreach (var client in clients)
                IoC.Application_Work.All_Users.Add(client);
            foreach (var employee in employees)
                IoC.Application_Work.All_Users.Add(employee);
            foreach (var car in cars)
                IoC.Application_Work.All_Cars.Add(car);
            foreach (var route in routes)
                IoC.Application_Work.All_Routes.Add(route);
            foreach (var product in products)
                IoC.Application_Work.All_Orders.Add(product);
        }
        public static async void            Set_User_Async(User user)
        {
            IoC.Application_Work.All_Users.Add(user);
            using var context = new ApplicationDbContext();
            if (user is Client)
                await context.Clients.AddAsync(user as Client);
            else
                await context.Employees.AddAsync(user as Employee);
            await context.SaveChangesAsync();
        }
        public static async void            Set_Car_Async(Car car)
        {
            IoC.Application_Work.All_Cars.Add(car);
            using var context = new ApplicationDbContext();
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
        }
        public static async void            Set_Routes_Async(Route route)
        {
            IoC.Application_Work.All_Orders.Add(route.Product);
            (IoC.Application_Work.Current_User as Client).Products.Add(route.Product);
            IoC.Application_Work.All_Routes.Add(route);
            using var context = new ApplicationDbContext();
            if (IoC.Application_Work.Current_User is Client)
            {
                var client = context.Clients.First(u => u.Login == IoC.Application_Work.Current_User.Login);
                client.Products.Add(route.Product);
                await Task.Run(() => context.Clients.Update(client));
            }
            await context.Routes.AddAsync(route);
            await context.SaveChangesAsync();
        }
        public static async void            Update_Product_Async(Product product, StatusOfProduct statusOfProduct)
        {
            IoC.Application_Work.All_Orders.First(p => p.Id == product.Id).Status = statusOfProduct;
            if (IoC.Application_Work.Current_User is Client client)
                client.Products.First(p => p.Id == product.Id).Status = statusOfProduct;
            foreach (var user in IoC.Application_Work.All_Users)
                if (user is Client cl && cl.Products.FirstOrDefault(p => p.Id == product.Id) != null)
                    cl.Products.FirstOrDefault(p => p.Id == product.Id).Status = statusOfProduct;
            IoC.Application_Work.All_Routes.First(p => p.Product.Id == product.Id).Product.Status = statusOfProduct;
            using var context = new ApplicationDbContext();
            var dbProduct = context.Products.First(p => p.Id == product.Id);
            dbProduct.Status = statusOfProduct;
            if (IoC.Application_Work.Current_User is Client)
            {
                var dbClient = context.Clients.First(u => u.Login == IoC.Application_Work.Current_User.Login);
                dbClient.Products.First(p => p.Id == product.Id).Status = statusOfProduct;
                await Task.Run(() => context.Clients.Update(dbClient));
            }
            await Task.Run(() => context.Products.Update(dbProduct));
            await context.SaveChangesAsync();
        }
        public static async void            Update_Car_Async(Car car, Route route)
        {
            IoC.Application_Work.All_Cars.First(c => c.Id == car.Id).CurrentRoute = route;
            IoC.Application_Work.All_Cars.First(c => c.Id == car.Id).Routes.Add(route);
            using var context = new ApplicationDbContext();
            var dbCar = context.Cars.First(c => c.Id == car.Id);
            dbCar.CurrentRoute = route;
            dbCar.Routes.Add(route);
            await Task.Run(() => context.Cars.Update(dbCar));
            await context.SaveChangesAsync();
        }
    }
}
