using DataAccessLayer.Concrete;
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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}