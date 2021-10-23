using AppCoffeApplication.OrderModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders(int id)
        {
            return Ok(await _orderService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderDTOs request)
        {
            var status = await _orderService.Create(request);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] OrderDTOs request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var status = await _orderService.Update(id, request);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var status = await _orderService.Delete(id);
            return Ok(status);
        }
    }
}
