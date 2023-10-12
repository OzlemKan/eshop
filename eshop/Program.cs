using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eshop.Data;
using eshop.Data.Cart;
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
    
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
        app.UseSession();



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
                    if (passwordCheck)
                    {
                        try
                        {
                            var issuer = builder.Configuration["Jwt:Issuer"];
                            var audience = builder.Configuration["Jwt:Audience"];
                            var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new[]
                                {
                                    new Claim("Id", Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                }),
                                Expires = DateTime.UtcNow.AddMinutes(5),
                                Issuer = issuer,
                                Audience = audience,
                                SigningCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha512Signature)
                            };
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var token = tokenHandler.CreateToken(tokenDescriptor);
                            var jwtToken = tokenHandler.WriteToken(token);
                            var stringToken = tokenHandler.WriteToken(token);

                            // Return the JWT token as a success result
                            return Results.Ok(new { token = stringToken });
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions that occur during token generation
                            // Log the exception or return an error response
                            return Results.StatusCode(500);
                        }
                    }
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

