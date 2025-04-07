using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Exceptions;
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
        var restaurants = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(res=> res.Id == id );
        
        return restaurants;
    }

    public async Task<int> Create(Restaurant restaurant)
    {
        dbContext.Restaurants.Add(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task Delete(int id)
    {
        var restaurant = await dbContext.Restaurants.FindAsync(id);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurants), id.ToString());
        dbContext.Restaurants.Remove(restaurant);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
