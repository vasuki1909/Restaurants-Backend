using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;


public interface IRestaurantsRepository
{
    public Task<IEnumerable<Restaurant>> GetAll();

    public Task<Restaurant?> GetById(int id);
    
    public Task<int> Create(Restaurant restaurant);

    public Task Delete(int id);

    public Task SaveChanges();
}