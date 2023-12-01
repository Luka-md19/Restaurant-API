using Resturant.API.Models.MenuItem;
namespace Resturant.API.Models.MenuCategory


{
    public class MenuCategoryDto : BaseMenuCategoryDto
    {
        public int CategoryID { get; set; }
        public virtual IList<MenuItemDto> MenuItems { get; set; } 
    }
}
