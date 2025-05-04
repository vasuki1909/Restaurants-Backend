using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    public Task<int> Create(Dish Dish);
    public Task<IEnumerable<Dish>> GetAllDishesByRestaurantId(int restaurantId);
}