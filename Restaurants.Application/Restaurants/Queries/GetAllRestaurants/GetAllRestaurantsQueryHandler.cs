using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler( ILogger<GetRestaurantByIdQueryHandler> logger, 
    IMapper mapper, 
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantsDto>>
{
    public async Task<IEnumerable<RestaurantsDto>> Handle(
        GetAllRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        
        var restaurants = await restaurantsRepository.GetAll();
        //Without using automapper.
        // var restaurantsDto = restaurants.Select(RestaurantsDto.FromEntity); // (r => RestaurantsDto.FromEntity(r));

        var restaurantsDto = mapper.Map<IEnumerable<RestaurantsDto>>(restaurants);
        return restaurantsDto;
    }
    
}