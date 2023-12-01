using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Models.MenuCategory;

namespace Resturant.API.Repository
{
    public class MenuCategories : GenericRepository<MenuCategory>, IMenuCategories
    {
        private readonly ResturantDbContext _context;
        private readonly IMapper _mapper;

        public MenuCategories(ResturantDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<MenuCategoryDto> GetDetails(int id)
        {
            var menuCategory = await _context.MenuCategories.Include(q => q.MenuItems)
                .ProjectTo<MenuCategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.CategoryID == id);

            if (menuCategory == null)
            {
                return null;
            }
            return menuCategory;
        }
    }
}
