using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.Schema;
using Resturant.API.Data.Schema;
using Resturant.API.Exceptions;

namespace Resturant.API.Repository
{
    public class RestaurantDataRepository : GenericRepository<RestaurantData>, IRestaurantDataRepository
    {
        private readonly ResturantDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantDataRepository(ResturantDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      


    }
}
