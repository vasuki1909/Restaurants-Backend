using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesForRestaurant;

public class GetAllDishesForRestaurantQueryHandler(
    ILogger<GetAllDishesForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository, IMapper mapper
    ): IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesForRestaurantQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dishes for restaurant {RestaurantId}", query.RestaurantId);
        var restaurant = await restaurantsRepository.GetById(query.RestaurantId);
        if(restaurant==null)
            throw new NotFoundException(nameof(Restaurant), query.RestaurantId.ToString());

        return mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
        // // actually no need to use dishes restaurant already has dishes included while fetching
        // var dishes = await dishesRepository.GetAllDishesByRestaurantId(query.RestaurantId);
        // var dishesDtos = mapper.Map<IEnumerable<DishDto>>(dishes);
        // return dishesDtos;
    }
}