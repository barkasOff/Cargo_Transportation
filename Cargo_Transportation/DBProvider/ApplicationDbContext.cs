using Cargo_Transportation.Models;
using Microsoft.EntityFrameworkCore;

namespace Cargo_Transportation.DBProvider
{
    public class                    ApplicationDbContext : DbContext
    {
        public DbSet<Client>        Clients { get; set; }
        public DbSet<Employee>      Employees { get; set; }
        public DbSet<Car>           Cars { get; set; }
        public DbSet<Product>       Products { get; set; }
        public DbSet<Route>         Routes { get; set; }

        protected override void     OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=password");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=CTC; Trusted_Connection=True");
        }
    }
}
