using eshop.Data.Static;
using eshop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data;

public class AppDbInitializer
{

    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        {

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "ozlemm-03@hotmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    FirstName = "Ozlem",
                    LastName = "Kandemir",
                    UserName = "admin",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                    Address = "address",
                    PhoneNumber = "098765",
                    Birthday = new DateOnly(1990, 1, 1)

                };
                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }


            const string appUserEmail = "ozlemphotos2309@gmail.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser()
                {
                    FirstName = "test",
                    LastName = "test",
                    UserName = "testcustomer",
                    Address = "address",
                    PhoneNumber = "098765",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    Birthday = new DateOnly(1990, 1, 1)

                };
                var createAppUserResult = await userManager.CreateAsync(newAppUser, "Coding@1234?");

                if (createAppUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
                else
                {
                    // Handle user creation failure (log or throw an exception)
                    // You can log createAppUserResult.Errors to diagnose the issue
                    throw new Exception($"App user creation failed: {string.Join(", ", createAppUserResult.Errors)}");
                }
            }
        }
        
    }
}

