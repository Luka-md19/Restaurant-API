using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.ItemDescription;
using Resturant.API.Repository;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDescriptionsController : ControllerBase
    {
        private readonly IItemDescriptionRepository _itemDescriptionsRepository;

        public ItemDescriptionsController(IItemDescriptionRepository itemDescriptionsRepository)
        {
            _itemDescriptionsRepository = itemDescriptionsRepository;
        }

        // GET: api/ItemDescriptions
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetItemDescriptionDto>>> GetItemDescriptions()
        {
            var records = await _itemDescriptionsRepository.GetAllAsync<GetItemDescriptionDto>();
            return Ok(records);
        }

        // GET: api/ItemDescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDescriptionDto>> GetItemDescription(int id)
        {
            var itemDescriptionDto = await _itemDescriptionsRepository.GetAsync<ItemDescriptionDto>(id);
            return Ok(itemDescriptionDto);
        }

        // PUT: api/ItemDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDescription(int id, ItemDescriptionDto itemDescriptionDto)
        {
            if (id != itemDescriptionDto.ItemID)
            {
                return BadRequest();
            }
            try
            {
                await _itemDescriptionsRepository.UpdateAsync<ItemDescriptionDto>(id, itemDescriptionDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemDescriptionExists(id))
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

        // POST: api/ItemDescriptions
        [HttpPost]
        public async Task<ActionResult<ItemDescription>> PostItemDescription(CreateItemDescriptionDto createItemDescriptionDto)
        {
            var itemDescriptionDto = await _itemDescriptionsRepository.AddAsync<CreateItemDescriptionDto, GetItemDescriptionDto>(createItemDescriptionDto);

            return CreatedAtAction("GetItemDescription", new { id = itemDescriptionDto.ItemID }, itemDescriptionDto);
        }


        // DELETE: api/ItemDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDescription(int id)
        {
            await _itemDescriptionsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> ItemDescriptionExists(int id)
        {
            return await _itemDescriptionsRepository.Exists(id);
        }
    }
}



git commit -m "Initial commit of Market-Summary project"
git branch -M main
git remote add origin https://github.com/Luka-md19/Market-Summary.git
git push -f origin main