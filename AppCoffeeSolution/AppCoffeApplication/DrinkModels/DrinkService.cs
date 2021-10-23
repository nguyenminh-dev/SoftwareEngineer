using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.DrinkModels
{
    public class DrinkService : IDrinkService
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        public DrinkService(AppCoffeeDbContext appCoffeeDbContext)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
        }
        public async Task<int> Get(int id)
        {
            var department = await _appCoffeeDbContext.Departments.FindAsync(id);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Create(DrinkDTOs request)
        {
            var drink = new Drink()
            {
                Name = request.Name,
                CategoryID= request.CategoryID,
                Price = request.Price,
                Available = request.Available
            };
            _appCoffeeDbContext.Drinks.Add(drink);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, DrinkDTOs request)
        {
            var drink = new Drink()
            {
                Id = request.Id,
                Name = request.Name,
                CategoryID = request.CategoryID,
                Price = request.Price,
                Available = request.Available
            };
            _appCoffeeDbContext.Drinks.Update(drink);
            _appCoffeeDbContext.SaveChanges();
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var drink = await _appCoffeeDbContext.Drinks.FindAsync(id);
            _appCoffeeDbContext.Drinks.Remove(drink);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<DrinkDTOs>> GetAll()
        {
            var respose = await _appCoffeeDbContext.Drinks.Select(x => new DrinkDTOs()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryID = x.CategoryID,
                Price = x.Price,
                Available = x.Available,
                CategoryName = x.Category.Name
            }).ToListAsync();
            return respose;
        }

    }
}
