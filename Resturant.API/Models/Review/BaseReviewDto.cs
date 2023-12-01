namespace Resturant.API.Models.Review
{
    public abstract class BaseReviewDto
    {
        public int ItemID { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
