using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.TableModels
{
    
    public class TableService : ITableService
    {
        
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        
        public TableService(AppCoffeeDbContext appCoffeeDbContext)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
        }
       
        public async Task<int> Create()
        {
            var max = _appCoffeeDbContext.Tables.Count() + 1;
            var table = new Table()
            {
                Name = "Bàn " + max.ToString(),
                Available = true
            };
            _appCoffeeDbContext.Tables.Add(table);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        
        public async Task<int> Update(int id)
        {
            
            var table = _appCoffeeDbContext.Tables.SingleOrDefault(t => t.Id == id);       
            table.Available = !(table.Available);
            
            _appCoffeeDbContext.Tables.Update(table);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete()
        {
            //var table = await _appCoffeeDbContext.Tables.FindAsync(_appCoffeeDbContext.Tables.Last());
            _appCoffeeDbContext.Tables.Remove(_appCoffeeDbContext.Tables.OrderBy(x => x.Id).Last());
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<TableDTOs>> GetAll()
        {
            
            var response = await _appCoffeeDbContext.Tables.Select(x => new TableDTOs()
            {
                Id = x.Id,
                Name = x.Name,
                Available = x.Available
            }).ToListAsync();
            return response;
        }
    }
}
