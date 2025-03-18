using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Resturant.API.Contract;
using Resturant.API.Models.Schema;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Models.ItemDescription;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDatasController : ControllerBase
    {
        private readonly IRestaurantDataRepository _restaurantDataRepository;
        private readonly IMapper _mapper;

        public RestaurantDatasController(IRestaurantDataRepository restaurantDataRepository, IMapper mapper)
        {
            _restaurantDataRepository = restaurantDataRepository;
            _mapper = mapper;
        }

        // GET: api/RestaurantDatas
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetRestaurantDataDto>>> GetRestaurantData()
        {
            var records = await _restaurantDataRepository.GetAllAsync<GetRestaurantDataDto>();
            return Ok(records);
        }

        // GET: api/RestaurantDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDataDto>> GetRestaurantData(int id)
        {
            var restaurantDataDto = await _restaurantDataRepository.GetAsync<RestaurantDataDto>(id);
            return Ok(restaurantDataDto);
        }

        // PUT: api/RestaurantDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantData(int id, RestaurantDataDto updateRestaurantDataDto)
        {
            if (id != updateRestaurantDataDto.Id)
            {
                return BadRequest();
            }
            try
            {
                await _restaurantDataRepository.UpdateAsync(id, updateRestaurantDataDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RestaurantDataExists(id))
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

        // POST: api/RestaurantDatas
        [HttpPost]
        public async Task<ActionResult<RestaurantDataDto>> PostRestaurantData(CreateRestaurantDataDto createRestaurantDataDto)
        {
            var restaurantDataDto = await _restaurantDataRepository.AddAsync<CreateRestaurantDataDto, GetRestaurantDataDto>(createRestaurantDataDto);
            return CreatedAtAction("GetRestaurantData", new { id = restaurantDataDto.Id }, restaurantDataDto);
        }

        // DELETE: api/RestaurantDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantData(int id)
        {
            await _restaurantDataRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> RestaurantDataExists(int id)
        {
            return await _restaurantDataRepository.Exists(id);
        }
    }
}
