using AppCoffeeData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Models
{
    public class AppCoffeeDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppCoffeeDbContext(DbContextOptions<AppCoffeeDbContext> options) : base(options)
        {

        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Department>().HasData(
                    new Department
                    {
                        Id = 1,
                        Name = "Admin"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "Khách hàng"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "Pha chế"
                    },
                    new Department
                    {
                        Id = 4,
                        Name = "Thu ngân"
                    }
                );

        }


    }
}
