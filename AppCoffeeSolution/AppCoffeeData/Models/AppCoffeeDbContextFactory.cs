using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeeData.Models
{
    public class AppCoffeeDbContextFactory : IDesignTimeDbContextFactory<AppCoffeeDbContext>
    {
        public AppCoffeeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppCoffeeDbContext>();
            optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=AppCoffee;Trusted_Connection=True;");
            return new AppCoffeeDbContext(optionsBuilder.Options);
        }
    }
}
