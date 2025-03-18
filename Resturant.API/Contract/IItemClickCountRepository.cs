using Microsoft.EntityFrameworkCore;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Repository;

public interface IItemClickCountRepository : IGenericRepository<ItemClickCount>
{
    void IncrementClickCount(int itemId);
}


