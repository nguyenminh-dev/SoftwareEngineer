using AppCoffeApplication.CategoryModels;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategorys(int id)
        {
            return Ok(await _categoryService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryDTOs request)
        {
            var status = await _categoryService.Create(request);
            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] CategoryDTOs request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var status = await _categoryService.Update(id, request);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var status = await _categoryService.Delete(id);
            return Ok(status);
        }
    }
}
