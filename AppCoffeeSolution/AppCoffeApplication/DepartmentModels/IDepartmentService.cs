using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.DepartmentModels
{
    public interface IDepartmentService
    {
        public Task<int> Create(DepartmentDTOs request);
        public Task<int> Get(int id);
        public Task<int> Update(int id, DepartmentDTOs request);
        public Task<int> Delete(int id);
        public Task<List<DepartmentDTOs>> GetAll();

    }
}
