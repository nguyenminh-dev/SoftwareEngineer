using AppCoffeApplication.DepartmentModels;
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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            return Ok(await _departmentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartments(int id)
        {
            return Ok(await _departmentService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] DepartmentDTOs request)
        {
            var status = await _departmentService.Create(request);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, [FromBody] DepartmentDTOs request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var status = await _departmentService.Update(id, request);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var status = await _departmentService.Delete(id);
            return Ok(status);
        }

    }
}
