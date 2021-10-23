using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.OrderModels
{
    public interface IOrderService
    {
        public Task<int> Create(OrderDTOs request);
        public Task<int> Get(int id);
        public Task<int> Update(int id, OrderDTOs request);
        public Task<int> Delete(int id);
        public Task<List<OrderDTOs>> GetAll();
    }
}
