namespace Resturant.API.Models.SpecialOffer
{
    public abstract class BaseSpecialDto
    {
        public string OfferName { get; set; }
        public string OfferDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
