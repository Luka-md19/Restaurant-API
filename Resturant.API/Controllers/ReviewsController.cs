using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.Review;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewsRepository;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRepository reviewsRepository , IMapper mapper)
        {
            this._reviewsRepository = reviewsRepository;
            this._mapper = mapper;
        }

        // GET: api/Reviews
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetReviewDto>>> GetReviews()
        {
            var records = await _reviewsRepository.GetAllAsync<GetReviewDto>();
            return Ok(records);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReview(int id)
        {
            var reviewDto = await _reviewsRepository.GetAsync<ReviewDto>(id);
            return Ok(reviewDto);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewDto reviewDto)
        {
            if (id != reviewDto.ReviewID)
            {
                return BadRequest();
            }
            try
            {
                await _reviewsRepository.UpdateAsync<ReviewDto>(id, reviewDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReviewExists(id))
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

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(CreateReviewDto createReviewDto)
        {
            var reviewDto = await _reviewsRepository.AddAsync<CreateReviewDto, GetReviewDto>(createReviewDto);

            return CreatedAtAction("GetReview", new { id = reviewDto.ReviewID }, reviewDto);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> ReviewExists(int id)
        {
            return await _reviewsRepository.Exists(id);
        }
    }
}
