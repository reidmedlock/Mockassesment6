using Microsoft.EntityFrameworkCore;
using Mockassesment6.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// NEW LINES OF CODE FOR EF
IConfigurationBuilder buildConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
IConfiguration configuration = buildConfig.Build();
builder.Services.AddDbContext<Employee2Db>(options => options.UseSqlServer(configuration.GetConnectionString(""))); // Make sure to use the right name
// END OF NEW LINES
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
