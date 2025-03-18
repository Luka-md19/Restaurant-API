namespace Resturant.API.Models.AccountConfiguration
{
    public abstract class BaseAccountConfigurationDto
    {
        public string RestaurantId { get; set; }

        public string Schema { get; set; }

        public string Email { get; set; }

    }
}
