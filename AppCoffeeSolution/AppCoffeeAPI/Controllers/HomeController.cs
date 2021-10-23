using AppCoffeApplication.BillModels;
using AppCoffeApplication.UserModels;
using AppCoffeeData.Entities;
using AppCoffeeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace AppCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly IBillService _billService;
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCurrentUser([FromBody] UserDTOs request)
        //{

        //}

        public HomeController(
            UserManager<ApplicationUser> userManager,
            IUserService userService,
            AppCoffeeDbContext appCoffeeDbContext,
            IBillService billService)
        {
            _appCoffeeDbContext = appCoffeeDbContext;
            _userManager = userManager;
            _userService = userService;
            _billService = billService;
        }
        [HttpGet("{username}")]
        public async Task<int> GetDepartId(string username)
        {

           return await _userService.GetDepartmentId(username);
        }



        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            return Ok(await _billService.GetAll());
        }



    }
}
