using AutoMapper;
using Resturant.API.Contract;
using Resturant.API.Data;

namespace Resturant.API.Repository
{
    public class SpecialOffersRepository : GenericRepository<SpecialOffer>, ISpecialOffersRepository
    {
        private readonly ResturantDbContext _context;
        private readonly IMapper _mapper;

        public SpecialOffersRepository(ResturantDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
    }
}
