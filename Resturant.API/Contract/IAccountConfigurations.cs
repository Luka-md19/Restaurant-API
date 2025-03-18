using Resturant.API.Data;
using Resturant.API.Models.AccountConfiguration;
using Resturant.API.Models.MenuCategory;
using Resturant.API.Models.Schema;
using Resturant.API.Repository;

namespace Resturant.API.Contract
{
    public interface IAccountConfigurations : IGenericRepository<AccountConfiguration>
    {
        Task<AccountConfigurationDto> GetSchemaDetailsAsync(int accountId);
    }

}
