using AppCoffeApplication.TableModels;
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
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService TableService)
        {
            _tableService = TableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            return Ok(await _tableService.GetAll());
        }


        [HttpPost]
        public async Task<IActionResult> PostTable()
        {
            var status = await _tableService.Create();
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id)
        {
            
            var status = await _tableService.Update(id);
            return Ok(status);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTable()
        {
            var status = await _tableService.Delete();
            return Ok(status);
        }
    }
}
