using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FitnessUygulamasi.Data;
using FitnessUygulamasi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Baðlantýsýný Yapýlandýr
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Identity (Üyelik Sistemi) Ayarlarý
// Þifre kurallarýný hocanýn isteðine göre (basit 'sau' þifresi için) gevþetiyoruz.
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3; // 'sau' 3 harfli olduðu için
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. HTTP Ýstek Hattý (Pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Giriþ yapma (Kimlik Doðrulama)
app.UseAuthorization();  // Yetki kontrolü

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// --- SEED DATA BAÞLANGIÇ ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbSeeder.SeedRolesAndAdminAsync(services);
}



app.Run();