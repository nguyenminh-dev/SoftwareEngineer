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
using AppCoffeApplication.OrderModels;

namespace AppCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly AppCoffeeDbContext _appCoffeeDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IBillService _billService;


        public BillController(
            UserManager<ApplicationUser> userManager,
            IUserService userService,
            AppCoffeeDbContext appCoffeeDbContext,
            IBillService billService,
            IOrderService orderService
            )
        {
            _appCoffeeDbContext = appCoffeeDbContext;
            _userManager = userManager;
            _userService = userService;
            _billService = billService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            return Ok(await _billService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getbill(int id)
        {
            return Ok(await _billService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostBill([FromBody] BillDTOs request)
        {
            var status = await _billService.Create(request);
            
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, [FromBody] BillDTOs request)
        {
            
            if (request.DateCheckIn==null)
            {
                var status1 = await _billService.Finish(id);
                return Ok(status1);
            }    
            if (id != request.Id)
            {
                return BadRequest();
            }
            var status2 = await _billService.Update(id, request);
            return Ok(status2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var status = await _billService.Delete(id);
            return Ok(status);
        }


    }
}

