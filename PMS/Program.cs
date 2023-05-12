using Microsoft.EntityFrameworkCore;
using PMS;
using PMS.DAL.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews(config =>
{
    config.Filters.Add(new SessionFilter());
});

builder.Services.AddApplicationDependencies();
var connectionString = builder.Configuration.GetConnectionString("PMSConnectConnection");
builder.Services.AddDbContext<PmsdbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();
app.Run();
