using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(
    ILogger<UpdateRestaurantCommandHandler> logger, 
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper): IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);
        
        var restaurant = await restaurantsRepository.GetById(request.Id);
        if (restaurant == null)  throw new NotFoundException(nameof(Restaurants), request.Id.ToString()); 
        // restaurant.Name = request.Name;
        // restaurant.Description = request.Description;
        // restaurant.HasDelivery = request.HasDelivery;
        //or use mapper

        mapper.Map(request, restaurant);
        await restaurantsRepository.SaveChanges();
        // but i have seen we have better way like JsonPatchDocument  which we can use.
    }
}