using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.SpecialOffer;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOffersRepository _specialOffersRepository;

        public SpecialOffersController(ISpecialOffersRepository specialOffersRepository)
        {
            _specialOffersRepository = specialOffersRepository;
        }

        // GET: api/SpecialOffers
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetSpecialOfferDto>>> GetSpecialOffers()
        {
            var records = await _specialOffersRepository.GetAllAsync<GetSpecialOfferDto>();
            return Ok(records);
        }

        // GET: api/SpecialOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOfferDto>> GetSpecialOffer(int id)
        {
            var specialOfferDto = await _specialOffersRepository.GetAsync<SpecialOfferDto>(id);
            return Ok(specialOfferDto);
        }

        // PUT: api/SpecialOffers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialOffer(int id, SpecialOfferDto specialOfferDto)
        {
            if (id != specialOfferDto.OfferID)
            {
                return BadRequest();
            }
            try
            {
                await _specialOffersRepository.UpdateAsync<SpecialOfferDto>(id, specialOfferDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SpecialOfferExists(id))
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

        // POST: api/SpecialOffers
        [HttpPost]
        public async Task<ActionResult<SpecialOffer>> PostSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var specialOfferDto = await _specialOffersRepository.AddAsync<CreateSpecialOfferDto, GetSpecialOfferDto>(createSpecialOfferDto);

            return CreatedAtAction("GetSpecialOffer", new { id = specialOfferDto.OfferID }, specialOfferDto);
        }

        // DELETE: api/SpecialOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(int id)
        {
            await _specialOffersRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> SpecialOfferExists(int id)
        {
            return await _specialOffersRepository.Exists(id);
        }
    }
}
