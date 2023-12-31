using Character_Management.MVC.Contracts;
using Character_Management.MVC.Services;
using Character_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

namespace Character_Management.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = "/Users/Login";
            });

            builder.Services.AddHttpClient<IClient,Client>(c => c.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<ICharacterTypeService,CharacterTypeService>();
            builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{Id?}");

            app.Run();
        }
    }
}