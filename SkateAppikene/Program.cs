using Microsoft.EntityFrameworkCore;
using SkateAppikene.Data;
using SkateAppikene.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=skateappikene.db"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var db =
        scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    if (!db.Users.Any(u =>
        u.Email == "admin@skateapp.ee"))
    {
        var admin = new User
        {
            Eesnimi = "Admin",
            Perenimi = "Admin",
            Email = "admin@skateapp.ee",
            Kasutajanimi = "admin",
            ParoolHash =
                BCrypt.Net.BCrypt.HashPassword(
                "SkateAdmin2025!"),
            Tase = "Admin"
        };

        db.Users.Add(admin);

        db.SaveChanges();
    }
}
app.Run();