using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCMusicStore.ViewModels;

namespace MVCMusicStore.Models
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@admin.com";
            string password = "Superadmin07$";

            if (await roleManager.FindByNameAsync("admin") == null)
                await roleManager.CreateAsync(new IdentityRole("admin"));
            if (await roleManager.FindByNameAsync("employee") == null)
                await roleManager.CreateAsync(new IdentityRole("employee"));
            if (await roleManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User {Email = adminEmail, UserName = adminEmail};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
            }
                
        }
    }
}
