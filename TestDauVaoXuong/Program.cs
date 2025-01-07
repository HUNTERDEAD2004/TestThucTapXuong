using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TestDauVaoXuong.IService;
using TestDauVaoXuong.Models;
using TestDauVaoXuong.Service;

namespace TestDauVaoXuong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ??ng ký DbContext v?i DI container
            builder.Services.AddDbContext<AppDbcontext>(options =>
                options.UseSqlServer("Data Source=DESKTOPD-DELLIN\\SQLEXPRESS;Database=exam_distribution_test;Trusted_Connection=True;TrustServerCertificate=True;"));

            // ??ng ký các d?ch v? khác
            builder.Services.AddScoped<IStaffServices, StaffService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Staff}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
