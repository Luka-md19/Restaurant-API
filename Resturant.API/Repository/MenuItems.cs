using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.MenuItem;

namespace Resturant.API.Repository
{
    public class MenuItems : GenericRepository<MenuItem>, IMenuItems
    {
        private readonly ResturantDbContext _context;
        private readonly IMapper _mapper;

        public MenuItems(ResturantDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<MenuItemDto> GetMenuItemsDetails(int id)
        {
            var menuItem = await _context.MenuItems
                .Include(mi => mi.ItemDescription)
                .Include(mi => mi.Reviews) 
                .ProjectTo<MenuItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(mi => mi.ItemID == id);

            if (menuItem == null)
            {
                return null;
            }
            

            return menuItem;
        }
    }
}
