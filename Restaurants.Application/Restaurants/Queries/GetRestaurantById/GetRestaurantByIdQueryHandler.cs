using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler( 
    ILogger<GetRestaurantByIdQueryHandler> logger, 
    IMapper mapper, 
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsDto>
{
    public async Task<RestaurantsDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting restaurant by {RestaurantId}", request.Id);
        var restaurant =  await restaurantsRepository.GetById(request.Id) ?? 
                          throw new NotFoundException(nameof(Restaurants), request.Id.ToString());
        var restaurantsDto = mapper.Map<RestaurantsDto>(restaurant);
        //destination      // source
        return restaurantsDto;
    }
}
