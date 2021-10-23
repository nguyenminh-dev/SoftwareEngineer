using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.CategoryModels
{
    public interface ICategoryService
    {
        public Task<int> Create(CategoryDTOs request);
        public Task<int> Get(int id);
        public Task<int> Update(int id, CategoryDTOs request);
        public Task<int> Delete(int id);
        public Task<List<CategoryDTOs>> GetAll();
    }
}
