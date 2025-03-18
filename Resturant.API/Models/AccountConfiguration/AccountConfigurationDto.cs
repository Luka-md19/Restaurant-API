using Resturant.API.Data.Schema;
using Resturant.API.Models.Schema;

namespace Resturant.API.Models.AccountConfiguration
{
    public class AccountConfigurationDto : BaseAccountConfigurationDto
    {
        public int AccountId { get; set; }
        public IList<RestaurantDataDto> restaurantDatas { get; set; }

    }
}
