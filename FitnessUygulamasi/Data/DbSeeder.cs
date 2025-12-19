using Microsoft.AspNetCore.Identity;
using FitnessUygulamasi.Models;

namespace FitnessUygulamasi.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Kullanıcı Yöneticisi ve Rol Yöneticisi
            var userManager = service.GetService<UserManager<AppUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            // 1. Roller Var mı? Yoksa oluştur.
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Member"));

            // 2. Admin Kullanıcısı Var mı?
            var adminEmail = "g191210028@sakarya.edu.tr"; 
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Yusuf Admin",
                    EmailConfirmed = true
                };

                // Şifre: sau
                await userManager.CreateAsync(adminUser, "sau");

                // Rol Ata
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}