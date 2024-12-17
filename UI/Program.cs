using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using UI.Roles;

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


        // Authentication: Cookie ile kimlik doðrulama
        builder.Services.AddAuthentication("Cookies")
        .AddCookie(options =>
        {
            options.Cookie.Name = "Cookies"; // Cookie name
            options.LoginPath = "/Login/AdminLogin";  // Redirect path for unauthorized users
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Session expiry
        });

        // Authorization yapýlandýrmasý
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("A"));
        });

        builder.Services.AddRazorPages();

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

        app.UseAuthentication(); //Kimlik Doðrulama
        app.UseAuthorization();   // Yetkilendirme

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}