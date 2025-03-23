using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetAll()
    {
        IQueryable<Restaurant> restaurants = dbContext.Restaurants;
        
        return await restaurants.ToListAsync();
    }
    public async Task<Restaurant?> GetById(int id)
    {
        var restaurants = await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(res=> res.Id == id );
        
        return restaurants;
    }

}