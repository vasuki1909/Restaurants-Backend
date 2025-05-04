using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurant;

public class GetDishesByIdForRestaurantQueryHandler(
    IMapper mapper, 
    ILogger<GetDishesByIdForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository): IRequestHandler<GetDishesByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishesByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dish {DishId} for restaurant {RestaurantId}", request.RestaurantId, request.DishId);
        var restaurant = await restaurantsRepository.GetById(request.RestaurantId);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
        var dish = restaurant.Dishes.FirstOrDefault(dish => dish.Id == request.DishId);
        if (dish is null)
            throw new NotFoundException(nameof(Dish),request.DishId.ToString());
        return mapper.Map<DishDto>(dish);
    }
}