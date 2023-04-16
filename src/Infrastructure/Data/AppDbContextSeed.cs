using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
				await roleManager.CreateAsync(new IdentityRole("admin"));
				await roleManager.CreateAsync(new IdentityRole("teacher"));
				await roleManager.CreateAsync(new IdentityRole("student"));

				string defaultUserName = "zahra_bazghandi";
				var defaultUser = new AppUser { UserName = defaultUserName, Email = "bazghandizahra@ielts.ir" };
				await userManager.CreateAsync(defaultUser, "P@ssword");
				defaultUser = await userManager.FindByNameAsync(defaultUserName);
				await userManager.AddToRoleAsync(defaultUser, "admin");
				await userManager.AddToRoleAsync(defaultUser, "teacher");
                await userManager.AddToRoleAsync(defaultUser, "student");

                //string adminUserName = "mustafas18";
                //var adminUser = new AppUser { UserName = adminUserName, Email = "mustafa_bazghandi@yahoo.com" };
                //await userManager.CreateAsync(adminUser, "P@ssw0rd");
                //adminUser = await userManager.FindByNameAsync(adminUserName);
                //await userManager.AddToRoleAsync(adminUser, "admin");
                //await userManager.AddToRoleAsync(adminUser, "student");
            }
			catch (Exception ex)
            {
                Console.WriteLine($"Error: Can not seed database. {ex.Message}");
            }
          
        }
    }
}
