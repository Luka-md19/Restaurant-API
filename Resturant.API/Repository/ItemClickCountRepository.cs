using AutoMapper;
using Resturant.API.Data;

namespace Resturant.API.Repository
{
    public class ItemClickCountRepository : GenericRepository<ItemClickCount>, IItemClickCountRepository

    {
        private readonly ResturantDbContext _context;
        private readonly IMapper _mapper;

        public ItemClickCountRepository(ResturantDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void IncrementClickCount(int itemId)
        {
            var itemClick = _context.ItemClickCounts.FirstOrDefault(ic => ic.ItemID == itemId);
            if (itemClick != null)
            {
                itemClick.ClickCount += 1;
                _context.SaveChanges();
            }
        }
    }
}