using AppCoffeApplication.OrderModels;
using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.BillModels
{
    public class BillService : IBillService
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        
        public BillService(AppCoffeeDbContext appCoffeeDbContext)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
        }
        public async Task<int> Get(int id)
        {
            var Bill = await _appCoffeeDbContext.Bills.FindAsync(id);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Create(BillDTOs request)
        {
            //cái này HashSet thì mới chạy được, Còn không thì lôi
            //request.OrderList = new HashSet<Order>();
            var Bill = new Bill()
            {
                TableId = request.TableId,
                OrderList = request.OrderList,
                DateCheckIn = request.DateCheckIn,
                TotalPrice = request.TotalPrice,
            };
            
            _appCoffeeDbContext.Bills.Add(Bill);
            foreach (var item in request.OrderList)
            {
                item.BillID = Bill.Id;
                _appCoffeeDbContext.Orders.Add(item);
            }
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, BillDTOs request)
        {
            var Bill = new Bill()
            {
                Id = request.Id,
                TableId = request.TableId,

                OrderList = request.OrderList,
                TotalPrice = request.TotalPrice,
            };
            _appCoffeeDbContext.Bills.Update(Bill);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Finish(int id)
        {
            var bill = _appCoffeeDbContext.Bills.SingleOrDefault(t => t.Id == id);
            bill.DateCheckOut = DateTime.Today;

            _appCoffeeDbContext.Bills.Update(bill);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var Bill = await _appCoffeeDbContext.Bills.FindAsync(id);
            _appCoffeeDbContext.Bills.Remove(Bill);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<BillDTOs>> GetAll()
        {
            var respose = await _appCoffeeDbContext.Bills.Where(s=>s.DateCheckOut==null).Select(x => new BillDTOs()
            {
                Id = x.Id,
                TableId = x.TableId,
                TableName = x.Table.Name,
                OrderList = x.OrderList,
                DateCheckIn = x.DateCheckIn,
                TotalPrice = x.TotalPrice,
            }).ToListAsync();
            return respose;
        }
    }
}
