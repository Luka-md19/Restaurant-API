using Resturant.API.Data.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resturant.API.Data
{
    public class AccountConfiguration
    {
        [Key]
        public int AccountId { get; set; }
        public string RestaurantId { get; set; }

        public string Schema { get; set; }

        public string Email { get; set; }

        public virtual IList<RestaurantData> RestaurantDatas { get; set; }
    }
}
