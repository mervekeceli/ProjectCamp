using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Baðlantý dizesini "appsettings.json" dosyasýndan alýyoruz ve DbContext'i yapýlandýrýyoruz.
        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjectCamp;Trusted_Connection=True;MultipleActiveResultSets=true"));

        // Cookie Authentication'ý yapýlandýr
        builder.Services.AddAuthentication("Cookies")
        .AddCookie(options =>
        {
            options.Cookie.Name = "Cookies"; // Cookie name
            options.LoginPath = "/Login/AdminLogin";  // Redirect path for unauthorized users
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Session expiry
        });

        // Add session management
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddRazorPages();
        builder.Services.AddSession(); // Session için gerekli yapýlandýrmayý ekle

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/ErrorPage/Error/{0}");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseStatusCodePages();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseSession();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}