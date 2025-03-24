using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Services.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Services;

public class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService > logger, IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantsDto>> GetAllRestaurants()
    { 
        logger.LogInformation("Getting all restaurants");
        
        var restaurants = await restaurantsRepository.GetAll();
      //Without using automapper.
      // var restaurantsDto = restaurants.Select(RestaurantsDto.FromEntity); // (r => RestaurantsDto.FromEntity(r));

      var restaurantsDto = mapper.Map<IEnumerable<RestaurantsDto>>(restaurants);
        return restaurantsDto;
    }
    
    public async Task<RestaurantsDto?> GetRestaurantById(int id)
    { 
        logger.LogInformation($"Getting restaurant by {id}");
        var restaurants =  await restaurantsRepository.GetById(id);
        var restaurantsDto = mapper.Map<RestaurantsDto?>(restaurants );
                                    //destination      // souce
        return restaurantsDto;
       // var restaurantsDto = RestaurantsDto.FromEntity(restaurants); // (r => RestaurantsDto.FromEntity(r));

        return restaurantsDto;
    }

    public async Task<int> CreateRestaurant(CreateRestaurantDto restaurantdto)
    {
        logger.LogInformation($"Creating new restaurant {restaurantdto.Name}");
            // this will not take the infrastructure as a parameter as the infra model deoesnt know naythign baout the dto
            var restaurant = mapper.Map<Restaurant>(restaurantdto);
        int id = await restaurantsRepository.Create(restaurant);
        return id;
    }
}