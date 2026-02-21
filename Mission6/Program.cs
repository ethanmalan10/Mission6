using Microsoft.EntityFrameworkCore;
using Mission6.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers and views
builder.Services.AddControllersWithViews();

// Register the EF Core DbContext with SQLite, using the connection string from appsettings.json
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
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

app.Run();
