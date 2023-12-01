using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.MenuCategory;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoriesController : ControllerBase
    {
        private readonly IMenuCategories _menuCategoriesRepository;
        private readonly IMapper _mapper;

        public MenuCategoriesController(IMenuCategories menuCategoriesRepository, IMapper mapper)
        {
            
            this._menuCategoriesRepository = menuCategoriesRepository;
            this._mapper = mapper;
        }

        // GET: api/MenuCategories
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetMenuCategoryDto>>> GetMenuCategories()
        {
            var records = await _menuCategoriesRepository.GetAllAsync<GetMenuCategoryDto>();
            return Ok(records);
        }

        // GET: api/MenuCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCategoryDto>> GetMenuCategory(int id)
        {
            var MenuCategoryDto = await _menuCategoriesRepository.GetDetails(id);
            return Ok(MenuCategoryDto);
        }

        // PUT: api/MenuCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuCategory(int id, MenuCategoryDto menuCategoryDto)
        {
            if (id != menuCategoryDto.CategoryID)
            {
                return BadRequest();
            }
            try
            {
                await _menuCategoriesRepository.UpdateAsync(id, menuCategoryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await MenuCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuCategory>> PostMenuCategory(CreateMenuCategoryDto createMenuCategoryDto)
        {
            var menuCategoryDto = await _menuCategoriesRepository.AddAsync<CreateMenuCategoryDto, GetMenuCategoryDto>(createMenuCategoryDto);

            return CreatedAtAction("GetMenuCategory", new { id = menuCategoryDto.CategoryID }, menuCategoryDto);
        }

        // DELETE: api/MenuCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuCategory(int id)
        {
            await _menuCategoriesRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> MenuCategoryExists(int id)
        {
            return await _menuCategoriesRepository.Exists(id);
        }
    }
}
