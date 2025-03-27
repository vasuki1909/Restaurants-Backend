using MediatR;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;
                                                // here comes the response of this command
public class CreateRestaurantCommand :IRequest<int>
{
    //same data as createRestaurantDto
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Category { get; set; } = default!;

    public bool HasDelivery { get; set; }

    public string? ContactPhoneNumber { get; set; }
    
    public string? ContactEmail { get; set; }

    public string? City { get; set; }
    
    public string? Street { get; set; }
    
    public string? PostalCode { get; set; }
}