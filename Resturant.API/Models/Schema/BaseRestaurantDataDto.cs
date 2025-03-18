using System.ComponentModel.DataAnnotations;

namespace Resturant.API.Models.Schema
{
    public abstract class BaseRestaurantDataDto
    {
        [Required]
        public int AccountId { get; set; }
       


      
        public string RestaurantId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }

        public string Cover { get; set; }

        public string BrandCode { get; set; }

      
    }
}
