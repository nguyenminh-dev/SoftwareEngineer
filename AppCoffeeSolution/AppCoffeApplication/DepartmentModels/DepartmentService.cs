using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.DepartmentModels
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        public DepartmentService(AppCoffeeDbContext appCoffeeDbContext)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
        }
        public async Task<int> Get(int id)
        {
            var department = await _appCoffeeDbContext.Departments.FindAsync(id);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Create(DepartmentDTOs request)
        {
            var department = new Department()
            {
                Name = request.Name
            };
            _appCoffeeDbContext.Departments.Add(department);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, DepartmentDTOs request)
        {
            var department = new Department()
            {
                Id = request.Id,
                Name = request.Name
            };
            _appCoffeeDbContext.Departments.Update(department);
            _appCoffeeDbContext.SaveChanges();
            return await _appCoffeeDbContext.SaveChangesAsync();
         }

        public async Task<int> Delete(int id)
        {
            var department = await _appCoffeeDbContext.Departments.FindAsync(id);
            _appCoffeeDbContext.Departments.Remove(department);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<DepartmentDTOs>> GetAll()
        {
            var respose = await _appCoffeeDbContext.Departments.Select(x => new DepartmentDTOs()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return respose;
        }
    }
}
