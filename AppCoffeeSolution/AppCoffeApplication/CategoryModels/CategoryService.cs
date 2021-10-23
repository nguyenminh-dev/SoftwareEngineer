using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.CategoryModels
{
    public class CategoryService : ICategoryService
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        public CategoryService(AppCoffeeDbContext appCoffeeDbContext)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
        }
        public async Task<int> Get(int id)
        {
            var department = await _appCoffeeDbContext.Categories.FindAsync(id);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Create(CategoryDTOs request)
        {
            var category = new Category()
            {
                Name = request.Name
            };
            _appCoffeeDbContext.Categories.Add(category);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, CategoryDTOs request)
        {
            var category = new Category()
            {
                Id = request.Id,
                Name = request.Name
            };
            _appCoffeeDbContext.Categories.Update(category);
            _appCoffeeDbContext.SaveChanges();
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var category = await _appCoffeeDbContext.Categories.FindAsync(id);
            _appCoffeeDbContext.Categories.Remove(category);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryDTOs>> GetAll()
        {
            var respose = await _appCoffeeDbContext.Categories.Select(x => new CategoryDTOs()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return respose;
        }
    }
}
