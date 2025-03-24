using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos;

public class CreateRestaurantDto
{
    [StringLength(maximumLength:100, MinimumLength = 3 ,ErrorMessage = "Name should be more than 3 characters and less than 100 characters")]
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    [Required(ErrorMessage = "Insert a valid category")]
    public string Category { get; set; } = default!;

    public bool HasDelivery { get; set; }

    [Phone(ErrorMessage = "Please provide a valid phone number")]
    public string? ContactPhoneNumber { get; set; }
    
    [EmailAddress(ErrorMessage = "Please provide a valid email")]
    public string? ContactEmail { get; set; }

    public string? City { get; set; }
    
    public string? Street { get; set; }
    
    [RegularExpression(@"^\d{3}-\d{3}$", ErrorMessage = "Please provide a valid postal code(xxx-xxx)")]
    public string? PostalCode { get; set; }
}