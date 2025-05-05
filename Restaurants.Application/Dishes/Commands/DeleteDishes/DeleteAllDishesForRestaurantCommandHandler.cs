using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

public class DeleteAllDishesForRestaurantCommandHandler(
    ILogger<DeleteAllDishesForRestaurantCommandHandler> logger,
    IDishesRepository dishesRepository, IRestaurantsRepository restaurantsRepository): IRequestHandler<DeleteAllDishesForRestaurantCommand>
{
    public async Task Handle(DeleteAllDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting all dishes for restaurant {id}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetById(request.RestaurantId);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
        
        await dishesRepository.RemoveAllDishesByRestaurantId(restaurant.Dishes);
    }
}