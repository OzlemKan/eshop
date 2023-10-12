using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eshop.Data;
using eshop.Data.Services;
using eshop.Data.ViewComponents;
using eshop.Data.ViewModels;
using eshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Session;


namespace eshop;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
        builder.Services.AddControllersWithViews();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build() ?? throw new ArgumentNullException(
            "new ConfigurationBuilder()\n    .SetBasePath(builder.Environment.ContentRootPath)\n    .AddJsonFile(\"appsettings.json\", optional: false, reloadOnChange: true)\n    .Build()");



        builder.Services.AddScoped<eshop.Data.Cart.ShoppingCart>();

// APPDBCONTEXT
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();
        builder.Services.AddScoped(ShoppingCart.GetShoppingCart);
        builder.Services.AddSession();


//authorization and authentication

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddMemoryCache();


        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();




//authorisation

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapPost("/Account/Login",
            [AllowAnonymous] async (LoginVM loginVM,
                Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager) =>
            {
                var user = await userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var passwordCheck = await userManager.CheckPasswordAsync(user, loginVM.Password);
                   
                }

                // Return an unauthorized result if the user is not found or password check fails
                return Results.Unauthorized();
            });


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        

            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();


            app.Run();
        
    }
}

