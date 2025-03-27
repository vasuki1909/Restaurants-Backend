using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurantsByRestaurantId(int id)
    {
        var restaurants = await mediator.Send(new GetRestaurantByIdQuery(id));
        if (restaurants == null)
            return NotFound();
        
        return Ok(restaurants);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand restaurant)
    {
        var restaurantId = await mediator.Send(restaurant);
        
        return CreatedAtAction(nameof(GetRestaurantsByRestaurantId), new { id = restaurantId }, restaurantId);
    }
    
}