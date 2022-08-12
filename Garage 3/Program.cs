using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage_3.Data;
using Garage_3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Garage_3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Garage_3Context") ?? throw new InvalidOperationException("Connection string 'Garage_3Context' not found.")));
//Test
// Add services to the container.
builder.Services.AddControllersWithViews();

// Lade till ny service för Members personnummer som en select list
builder.Services.AddScoped<IGeneratePersonNumberSelectList, GeneratePersonNumberSelectList>();

builder.Services.AddScoped<IGenerateVehicleTypeSelectList, GenerateVehicleTypeSelectList>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
    pattern: "{controller=Members}/{action=Index}/{id?}");

app.Run();
