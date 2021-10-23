using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.TableModels
{
    public interface ITableService
    {
        public Task<int> Create();
        public Task<int> Update(int id);
        public Task<int> Delete();
        public Task<List<TableDTOs>> GetAll();
    }
}
