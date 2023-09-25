using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Data;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDescriptionsController : ControllerBase
    {
        private readonly ResturantDbContext _context;

        public ItemDescriptionsController(ResturantDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemDescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDescription>>> GetItemDescriptions()
        {
            return await _context.ItemDescriptions.ToListAsync();
        }

        // GET: api/ItemDescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDescription>> GetItemDescription(int id)
        {
            var itemDescription = await _context.ItemDescriptions.FindAsync(id);

            if (itemDescription == null)
            {
                return NotFound();
            }

            return itemDescription;
        }

        // PUT: api/ItemDescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDescription(int id, ItemDescription itemDescription)
        {
            if (id != itemDescription.ItemID)
            {
                return BadRequest();
            }

            _context.Entry(itemDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDescriptionExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemDescription>> PostItemDescription(ItemDescription itemDescription)
        {
            _context.ItemDescriptions.Add(itemDescription);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemDescriptionExists(itemDescription.ItemID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItemDescription", new { id = itemDescription.ItemID }, itemDescription);
        }

        // DELETE: api/ItemDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDescription(int id)
        {
            var itemDescription = await _context.ItemDescriptions.FindAsync(id);
            if (itemDescription == null)
            {
                return NotFound();
            }

            _context.ItemDescriptions.Remove(itemDescription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemDescriptionExists(int id)
        {
            return _context.ItemDescriptions.Any(e => e.ItemID == id);
        }
    }
}
