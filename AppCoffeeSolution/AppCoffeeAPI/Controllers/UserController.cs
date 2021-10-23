using AppCoffeApplication.UserModels;
using AppCoffeeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: UserController
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(string id)
        {
            return Ok(await _userService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDTOs request)
        {
            var status = await _userService.Create(request);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, [FromBody] UserDTOs request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var status = await _userService.Update(id, request);
            return Ok(status);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var status = await _userService.Delete(id);
            return Ok(status);
        }
        //[HttpGet("{username}")]
        //public async Task<int> GetDepartId(string username)
        //{
        //    return await _userService.GetDepartmentId(username);
        //}

    }
}
