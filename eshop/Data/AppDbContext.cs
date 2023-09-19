using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data
{
    public class AppDbContext : DbContext
    {
// AppDbContext est un constructor
        public AppDbContext(DbContextOptions<AppDbContext> options, DbSet<Orders> orders): base(options)
        {
            Orders = orders;
        }

        public DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=188.166.24.55;user=hamilton-8-eshopuser;password=ZD1OeczEFaoKlhRG;database=hamilton-8-eshop";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}