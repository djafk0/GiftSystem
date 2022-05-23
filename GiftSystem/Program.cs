using GiftSystem.DAL;
using GiftSystem.Data;
using GiftSystem.Data.Models;
using GiftSystem.Infrastructure;
using GiftSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder
    .Services.AddDbContext<GiftSystemDbContext>(options =>
        options.UseSqlServer(connectionString));

builder
    .Services.AddDatabaseDeveloperPageExceptionFilter()
    .AddTransient<ITransactionRepository, TransactionRepository>()
    .AddTransient<ITransactionService, TransactionService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<GiftSystemDbContext>();

builder.Services.AddControllersWithViews();

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

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
