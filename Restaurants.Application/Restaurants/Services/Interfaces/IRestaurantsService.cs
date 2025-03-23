using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Services.Interfaces;

public interface IRestaurantsService
{
    public Task<IEnumerable<RestaurantsDto>> GetAllRestaurants();

    public Task<RestaurantsDto?> GetRestaurantById(int id);
}