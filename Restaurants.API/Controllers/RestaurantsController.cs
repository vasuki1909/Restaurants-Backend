using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Services.Interfaces;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurantsByRestaurantId(int id)
    {
        var restaurants = await restaurantsService.GetRestaurantById(id);
        if (restaurants == null)
            return NotFound();
        
        return Ok(restaurants);
    }

    
    
}