using System.ComponentModel.DataAnnotations;

namespace Resturant.API.Data
{
    public class SpecialOffer
    {
        [Key]
        public int OfferID { get; set; }
        public string OfferName { get; set; }
        public string OfferDetails { get; set; }
        public DateTime StartDate { get; set; }  // Define when the offer begins
        public DateTime EndDate { get; set; }    // Define when the offer ends
        public bool IsActive { get; set; }       // Is the offer currently active?

        // Relationships
        public virtual IList<MenuItem> MenuItems { get; set; } = new List<MenuItem>(); // Items associated with the offer
    }
}
