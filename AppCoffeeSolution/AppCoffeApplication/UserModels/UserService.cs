using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
namespace AppCoffeApplication.UserModels
{
    public class UserService : IUserService
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(AppCoffeeDbContext appCoffeeDbContext, UserManager<ApplicationUser> userManager)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
            _userManager = userManager;
        }
        public async Task<int> Get(string id)
        {
            var user = await _appCoffeeDbContext.Users.FindAsync(id);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }
        public async Task<int> Create(UserDTOs request)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = request.UserName,
                Password = request.Password,
                FullName = request.FullName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                DepartmentID = request.DepartmentID,
                BeginWork = request.BeginWork
            };
            await _userManager.CreateAsync(user, user.Password);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(string id, UserDTOs request)
        {
            var user = _appCoffeeDbContext.Users.FirstOrDefault(u => u.Id == id);
            user.UserName = request.UserName;
            user.FullName = request.FullName;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            user.DepartmentID = request.DepartmentID;
            user.BeginWork = request.BeginWork;
            await _userManager.ChangePasswordAsync(user, user.Password, request.Password);
            user.Password = request.Password;
            _appCoffeeDbContext.Users.Update(user);
            _appCoffeeDbContext.SaveChanges();
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(string id)
        {
            var user = await _appCoffeeDbContext.Users.FindAsync(id);
            _appCoffeeDbContext.Users.Remove(user);
            return await _appCoffeeDbContext.SaveChangesAsync();
        }

        public async Task<List<UserDTOs>> GetAll()
        {
     
            var response = await _appCoffeeDbContext.Users.Select(x => new UserDTOs()
            {
                Id = x.Id,
                FullName= x.FullName,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                DepartmentID = x.DepartmentID,
                Password = x.Password,
                BeginWork = x.BeginWork,
                DepartmentName = x.Department.Name,
            }).ToListAsync();
            
            return response;
        }


        public async Task<int> GetDepartmentId(string username)
        {
            // var response = await _appCoffeeDbContext.Users.FirstOrDefault(u => u.UserName == username).DepartmentID;
            var user = await _userManager.FindByNameAsync(username);
            if (user!=null)
                return user.DepartmentID;
            return 0;
        }
    }
}
