using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.BillModels
{
    public interface IBillService
    {
        public Task<int> Create(BillDTOs request);
        public Task<int> Get(int id);
        public Task<int> Update(int id, BillDTOs request);
        public Task<int> Finish(int id);
        public Task<int> Delete(int id);
        public Task<List<BillDTOs>> GetAll();
    }
}
