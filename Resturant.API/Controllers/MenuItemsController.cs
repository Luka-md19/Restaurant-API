using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.MenuItem;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItems _menuItemsRepository;
        private readonly IMapper _mapper;

        public MenuItemsController(IMenuItems menuItemsRepository , IMapper mapper)
        {
            _menuItemsRepository = menuItemsRepository;
            this._mapper = mapper;
        }

        // GET: api/MenuItems
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetMenuItemsDto>>> GetMenuItems()
        {
            var records = await _menuItemsRepository.GetAllAsync<GetMenuItemsDto>();
            return Ok(records);
        }

        // GET: api/MenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItem(int id)
        {
            var MenuItemDto = await _menuItemsRepository.GetMenuItemsDetails(id);
            return Ok(MenuItemDto);
        }

        // PUT: api/MenuItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItemDto menuItemDto)
        {
            if (id != menuItemDto.ItemID)
            {
                return BadRequest();
            }
            try
            {
                await _menuItemsRepository.UpdateAsync(id, menuItemDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MenuItemExists(id))
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

        // POST: api/MenuItems
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(CreateMenuItemsDto createMenuItemDto)
        {
            var menuItemDto = await _menuItemsRepository.AddAsync<CreateMenuItemsDto, GetMenuItemsDto>(createMenuItemDto);

            return CreatedAtAction("GetMenuItem", new { id = menuItemDto.ItemID }, menuItemDto);
        }

        // DELETE: api/MenuItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuItemsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> MenuItemExists(int id)
        {
            return await _menuItemsRepository.Exists(id);
        }
    }
}
