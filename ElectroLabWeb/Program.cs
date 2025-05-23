using ElectroLabBusinessLayer.Interfaces;
using ElectroLabBusinessLayer.Services;
using ElectroLabDB;
using ElectroLabModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
namespace ElectroLabWeb;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultTokenProviders().AddDefaultUI();

        builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

        builder.Services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
        builder.Services.AddRazorPages();

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("bg-BG"),
            };

            options.DefaultRequestCulture = new RequestCulture("en", "en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            options.RequestCultureProviders = new[] { new CookieRequestCultureProvider() };
        });

        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IReportService, ReportService>();
        builder.Services.AddScoped<ITestService, TestService>();
        builder.Services.AddScoped<ITestSubmissionService, TestSubmissionService>();


        var app = builder.Build();

        app.UseRequestLocalization();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Owner", "Admin" };
            foreach (string role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role)))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}
