using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository
) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating new restaurant {request.Name}");
        // this will not take the infrastructure as a parameter as the infra model deoesnt know naythign baout the dto
        var restaurant = mapper.Map<Restaurant>(request);
        int id = await restaurantsRepository.Create(restaurant);
        return id;
    }
}