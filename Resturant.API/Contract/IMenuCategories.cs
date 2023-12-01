using Resturant.API.Data;
using Resturant.API.Models.MenuCategory;

namespace Resturant.API.Contract
{
    public interface IMenuCategories : IGenericRepository<MenuCategory>
    {
        Task<MenuCategoryDto> GetDetails(int id);
    }
}
