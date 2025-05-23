using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(
    ILogger<CreateDishCommandHandler> logger, 
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository,
    IMapper mapper): IRequestHandler<CreateDishCommand,int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish {@DishRequest}", request);
        var restaurant = await restaurantsRepository.GetById(request.RestaurantId);
        if(restaurant is null)
            throw new NotFoundException(nameof(Restaurants),request.RestaurantId.ToString());
        var dish = mapper.Map<Dish>(request);
        return await dishesRepository.Create(dish);
    }
}