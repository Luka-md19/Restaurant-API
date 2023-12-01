using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.API.Data
{
    public class MenuItem 
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemImage { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDishOfTheDay { get; set; }  // To highlight dish of the day




        [ForeignKey("OfferID")]
        public int? OfferID { get; set; }  // Nullable Foreign Key, make it nullable if it can be null
        public SpecialOffer SpecialOffer { get; set; }  // singular name

        [ForeignKey(nameof(CategoryID))]
        public int? CategoryID { get; set; }  // Make it nullable if it can be null
        public MenuCategory MenuCategory { get; set; } // singular name, kept only one property for MenuCategory
        // Relationships



        public virtual ItemDescription ItemDescription { get; set; } // singular name
        public virtual IList<Review> Reviews { get; set; } = new List<Review>();

        
    }
}
