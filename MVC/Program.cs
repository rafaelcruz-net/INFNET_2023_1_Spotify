using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MVC.Models.Account;
using MVC.Repository;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Adicionando ASP.NET Core Identity
            builder.Services.AddTransient<IUserStore<UserAccount>, UserAccountRepository>();
            builder.Services.AddTransient<IRoleStore<UserRole>, UserRoleRepository>();
            
            builder.Services.AddTransient<IAccountManager, AccountManager>();

            builder.Services.AddIdentity<Models.Account.UserAccount, Models.Account.UserRole>()
                            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/Login";
                config.AccessDeniedPath = "/Account/AccessDenied";
                config.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                config.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                
            });

            //Adicionando serviço de Sessão
            builder.Services.AddSession();

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

            app.UseAuthentication();
            app.UseAuthorization();

            //Ligando a sessão
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}