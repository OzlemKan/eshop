using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.Migrate();

        if (!context.Customers.Any())
        {
            context.Customers.AddRange(new List<Customers>()
            {
            new Customers()
            {
                FirstName = "Julie",
                LastName = "Dubois",
                Address = "rue Neuve 23, 1000 Bruxelles",
                Email = "julie@gmail.com",
                PhoneNumber = "045687654",
                Birthday = Convert.ToDateTime("1990-03-23")
            }
            
            });

            context.SaveChanges();
        }
    }
}