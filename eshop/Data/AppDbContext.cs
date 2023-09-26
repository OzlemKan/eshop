using eshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        //Orders related tables
        public DbSet<Orders> Orders { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=188.166.24.55;user=hamilton-8-eshopuser;password=ZD1OeczEFaoKlhRG;database=hamilton-8-eshop";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
            optionsBuilder.UseMySql(connectionString, serverVersion);

            
        }
    }
}

     


 

