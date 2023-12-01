using Resturant.API.Data;
using Resturant.API.Models.MenuItem;

namespace Resturant.API.Contract
{
    public interface IMenuItems : IGenericRepository<MenuItem>
    {
        Task<MenuItemDto> GetMenuItemsDetails(int id);
    }
}
