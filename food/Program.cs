using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using food.Areas.Identity.Data;
using food.Models;
using food;
using food.Helpers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("foodContextConnection") ?? throw new InvalidOperationException("Connection string 'foodContextConnection' not found.");

builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();

builder.Services.AddDbContext<foodContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ItemsContext>();

builder.Services.AddDefaultIdentity<foodUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<foodContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
