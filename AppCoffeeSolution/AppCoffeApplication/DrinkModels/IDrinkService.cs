using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.DrinkModels
{
    public interface IDrinkService
    {
        public Task<int> Create(DrinkDTOs request);
        public Task<int> Get(int id);
        public Task<int> Update(int id, DrinkDTOs request);
        public Task<int> Delete(int id);
        public Task<List<DrinkDTOs>> GetAll();
    }
}
