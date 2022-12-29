using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage_my_version.Data;
using Garage_my_version.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GarageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Garage_my_versionContext") ?? throw new InvalidOperationException("Connection string 'Garage_my_versionContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Bind a settings class to the configuration
builder.Services.Configure<GarageSettings>(options => builder.Configuration.GetSection("GarageSettings").Bind(options));


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

var dataText = System.IO.File.ReadAllText(@"Data/SeedData.json");
DbInitializer.Seeder(dataText, app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
