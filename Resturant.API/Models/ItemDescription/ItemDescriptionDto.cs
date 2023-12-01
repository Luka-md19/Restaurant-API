using Resturant.API.Models.MenuItem;

namespace Resturant.API.Models.ItemDescription
{
    public class ItemDescriptionDto : BaseItemDescriptionDto
    {
        public int ItemID { get; set; }
        public MenuItemDto MenuItems { get; set; }
    }
}
