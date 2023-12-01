using Resturant.API.Models.MenuItem;

namespace Resturant.API.Models.Review
{
    public class ReviewDto :BaseReviewDto
    {
        public int ReviewID { get; set; }
        public MenuItemDto MenuItem { get; set; }
    }
}
