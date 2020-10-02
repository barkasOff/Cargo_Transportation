using Cargo_Transportation.Models;
using Microsoft.EntityFrameworkCore;

namespace Cargo_Transportation.DBProvider
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=CargTransCompany; Trusted_Connection=True");
        }
    }
}
