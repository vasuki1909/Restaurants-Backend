using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetAllDishesForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurant;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants/{restaurantId}/[controller]")]
public class DishesController(IMediator mediator): ControllerBase
{
    // [HttpGet("{restaurantId}")]
    // public async Task<IActionResult> GetAllDishes(int restaurantId)
    // {
    //     await mediator.Send(new GetAllDishesQuery(restaurantId));
    // }
    
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, [FromBody] CreateDishCommand dish)
    {
        dish.RestaurantId = restaurantId;
        await mediator.Send(dish);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetByIdForRestaurant([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }
    
    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetAllDishesForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishesByIdForRestaurantQuery(restaurantId, dishId));
        return Ok(dish);
    }
}