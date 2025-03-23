using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Services.Interfaces;
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
        var restaurantsDto = mapper.Map<RestaurantsDto?>(restaurants);
       // var restaurantsDto = RestaurantsDto.FromEntity(restaurants); // (r => RestaurantsDto.FromEntity(r));

        return restaurantsDto;
    }
    
}