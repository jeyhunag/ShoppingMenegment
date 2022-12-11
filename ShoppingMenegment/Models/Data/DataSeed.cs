using ShoppingMenegment.Models.Entity.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShoppingMenegment.Models.Data
{
    public static class DataSeed
    {
        public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            const string adminEmail = "Jeyhunag@code.edu.az";
            const string adminPassword = "Ceka727727%";
            const string superAdminRoleName = "SuperAdmin";

            using (var scope = app.ApplicationServices.CreateScope())
            {

                var db = scope.ServiceProvider.GetRequiredService<ShoppingMenegmentContext>();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                db.Database.Migrate();

                var role = roleManager.FindByNameAsync(superAdminRoleName).Result;
                if (role == null)
                {
                    role = new AppRole
                    {
                        Name = superAdminRoleName
                    };

                    roleManager.CreateAsync(role).Wait();
                }


                var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var adminUser = userManeger.FindByEmailAsync(adminEmail).Result;

                if (adminUser == null)
                {
                    adminUser = new AppUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        EmailConfirmed = true
                    };

                    var userResult = userManeger.CreateAsync(adminUser, adminPassword).Result;

                    if (userResult.Succeeded)
                    {
                        userManeger.AddToRoleAsync(adminUser, superAdminRoleName).Wait();
                    }

                }
            }
            return app;
        }
    }
}
