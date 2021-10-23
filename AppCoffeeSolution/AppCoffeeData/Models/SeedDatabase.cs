using AppCoffeeData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Models
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppCoffeeDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "Admin",
                    FullName = "Admin",
                    PhoneNumber = "88888888",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Password = "Admin@123",
                    DepartmentID = 1
                };
                userManager.CreateAsync(user, "Admin@123");
            }
        }
    }
}
