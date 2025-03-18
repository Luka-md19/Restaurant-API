using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Exceptions;
using Resturant.API.Models.AccountConfiguration;
using Resturant.API.Repository;

public class AccountConfigurationsRepository : GenericRepository<AccountConfiguration>, IAccountConfigurations
{
    private readonly ResturantDbContext _context;
    private readonly IMapper _mapper;

    public AccountConfigurationsRepository(ResturantDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AccountConfigurationDto> GetSchemaDetailsAsync(int accountId)
    {
        var accountConfig = await _context.AccountConfigurations
            .Include(ac => ac.RestaurantDatas)
            .FirstOrDefaultAsync(ac => ac.AccountId == accountId);

        if (accountConfig == null)
        {
            throw new NotFoundException(nameof(GetSchemaDetailsAsync), accountId);
        }

        return _mapper.Map<AccountConfigurationDto>(accountConfig);


    }
}
