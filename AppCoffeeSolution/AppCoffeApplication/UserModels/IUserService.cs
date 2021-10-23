using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffeApplication.UserModels
{
    public interface IUserService
    {
        public Task<int> Create(UserDTOs request);
        public Task<int> Get(string id);
        public Task<int> Update(string id, UserDTOs request);
        public Task<int> Delete(string id);
        public Task<List<UserDTOs>> GetAll();

        public Task<int> GetDepartmentId(string username);
    }
}
