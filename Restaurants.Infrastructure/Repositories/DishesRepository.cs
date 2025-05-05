using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Infrastructure.Repositories;

public class DishesRepository(RestaurantsDbContext dbContext): IDishesRepository
{
    public async Task<int> Create(Dish dish)
    {
        dbContext.Dishes.Add(dish);
        await dbContext.SaveChangesAsync();
        return dish.Id;
    }

    public async Task<IEnumerable<Dish>> GetAllDishesByRestaurantId(int restaurantId)
    {
        IEnumerable<Dish> dishes = await dbContext.Dishes.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        return dishes;
    }
    
    public async Task RemoveAllDishesByRestaurantId(IEnumerable<Dish> dishes)
    {
        dbContext.Dishes.RemoveRange(dishes);
        await dbContext.SaveChangesAsync();
    }
}