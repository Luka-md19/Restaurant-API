using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.API.Data
{
    public class MenuItem
    {
        [Key]
        public int ItemID { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual MenuCategory MenuCategory { get; set; } // singular name
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemImage { get; set; }
        public int DisplayOrder { get; set; }

        // Relationships
        public virtual ItemDescription ItemDescription { get; set; } // singular name
        public virtual IList<Review> Reviews { get; set; } = new List<Review>();
        [ForeignKey(nameof(SpecialOfferID))]
        public int? SpecialOfferID { get; set; }  // Nullable Foreign Key
        public virtual SpecialOffer SpecialOffer { get; set; }  // singular name
        public bool IsDishOfTheDay { get; set; }  // To highlight dish of the day
    }
}
