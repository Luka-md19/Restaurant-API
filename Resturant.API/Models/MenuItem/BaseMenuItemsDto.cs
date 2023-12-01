using System.ComponentModel.DataAnnotations;

namespace Resturant.API.Models.MenuItem
{
    public  abstract class BaseMenuItemsDto
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int OfferID { get; set; }

        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemImage { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDishOfTheDay { get; set; }
    }
}
