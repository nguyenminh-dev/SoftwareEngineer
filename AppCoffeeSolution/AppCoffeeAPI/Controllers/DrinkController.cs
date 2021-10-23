using AppCoffeApplication.DrinkModels;
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
    public class DrinkController : ControllerBase
    {

        private readonly IDrinkService _drinkService;
        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrink()
        {
            return Ok(await _drinkService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrinks(int id)
        {
            return Ok(await _drinkService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostDrink([FromBody] DrinkDTOs request)
        {
            var status = await _drinkService.Create(request);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrink(int id, [FromBody] DrinkDTOs request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var status = await _drinkService.Update(id, request);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            var status = await _drinkService.Delete(id);
            return Ok(status);
        }
    }
}
