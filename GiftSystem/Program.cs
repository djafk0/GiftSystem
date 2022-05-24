using GiftSystem.DAL;
using GiftSystem.Data;
using GiftSystem.Data.Models;
using GiftSystem.Infrastructure;
using GiftSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<GiftSystemDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services
    .AddDatabaseDeveloperPageExceptionFilter()
    .AddTransient<ITransactionRepository, TransactionRepository>()
    .AddTransient<IUserRepository, UserRepository>()
    .AddTransient<ITransactionService, TransactionService>()
    .AddTransient<IUserService, UserService>()
    .AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GiftSystemDbContext>();

builder.Services.AddControllersWithViews((options
    => options.Filters
        .Add<AutoValidateAntiforgeryTokenAttribute>()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app
   .PrepareDatabase()
   .UseHttpsRedirection()
   .UseStaticFiles()
   .UseRouting()
   .UseAuthentication()
   .UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
