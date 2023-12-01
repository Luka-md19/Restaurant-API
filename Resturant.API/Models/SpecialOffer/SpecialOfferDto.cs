using Resturant.API.Models.MenuItem;

namespace Resturant.API.Models.SpecialOffer
{
    public class SpecialOfferDto : BaseSpecialDto
    {
        public int OfferID { get; set; }

        public  IList<MenuItemDto> MenuItems { get; set; } = new List<MenuItemDto>();  
    }
}
