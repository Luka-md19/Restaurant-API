using Resturant.API.Data;
using Resturant.API.Models.ItemDescription;
using Resturant.API.Models.MenuCategory;
using Resturant.API.Models.Review;
using Resturant.API.Models.SpecialOffer;

namespace Resturant.API.Models.MenuItem
{
    public class MenuItemDto : BaseMenuItemsDto
    {
        public int ItemID { get; set; }
        public  MenuCategoryDto MenuCategory { get; set; }
        public SpecialOfferDto SpecialOffers { get; set; }
        public IList<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
        public virtual ItemDescriptionDto ItemDescription { get; set; }

    }
}
