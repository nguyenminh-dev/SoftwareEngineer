using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.OrderModels
{
    public class OrderService : IOrderService
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        public OrderService(AppCoffeeDbContext appCoffeeDbContext)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
        }
        public async Task<int> Get(int id)
        {
            var department = await _appCoffeeDbContext.Orders.FindAsync(id);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Create(OrderDTOs request)
        {
            var order = new Order()
            {
                BillID = request.BillID,
                DrinkID = request.DrinkID,
                Quantity = request.Quantity,
                Price = request.Price,
                Status = request.Status,
                CustomReq = request.CustomReq,
                Note = request.Note
            };
            _appCoffeeDbContext.Orders.Add(order);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, OrderDTOs request)
        {
            var order = new Order()
            {
                Id = request.Id,
                BillID = request.BillID,
                DrinkID = request.DrinkID,
                Quantity = request.Quantity,
                Price = request.Price,
                Status = request.Status,
                CustomReq = request.CustomReq,
                Note = request.Note
            };
            _appCoffeeDbContext.Orders.Update(order);
            _appCoffeeDbContext.SaveChanges();
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var order = await _appCoffeeDbContext.Orders.FindAsync(id);
            _appCoffeeDbContext.Orders.Remove(order);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<OrderDTOs>> GetAll()
        {
            var respose = await _appCoffeeDbContext.Orders.Select(x => new OrderDTOs()
            {
                Id = x.Id,
                BillID = x.BillID,
                DrinkID = x.DrinkID,
                DrinkName = x.Drink.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                Status = x.Status,
                CustomReq = x.CustomReq,
                Note = x.Note
            }).ToListAsync();
            return respose;
        }
    }

}
