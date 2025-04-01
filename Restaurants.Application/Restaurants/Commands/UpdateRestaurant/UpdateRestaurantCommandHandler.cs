using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(
    ILogger<UpdateRestaurantCommandHandler> logger, 
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper): IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);
        
        var restaurant = await restaurantsRepository.GetById(request.Id);
        if (restaurant == null) return false;
        // restaurant.Name = request.Name;
        // restaurant.Description = request.Description;
        // restaurant.HasDelivery = request.HasDelivery;
        //or use mapper

        mapper.Map(request, restaurant);
        await restaurantsRepository.SaveChanges();
        return true;
        
        // but i have seen we have better way like JsonPatchDocument  which we can use.
    }
}