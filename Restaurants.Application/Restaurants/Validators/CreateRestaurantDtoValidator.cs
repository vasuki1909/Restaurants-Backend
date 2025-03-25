using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    
    private readonly List<string> validCategpry =
    [
        "Fast Food","Fine Dining", "Cafe", "Traditional", "Vegetarian", "Vegan", "Seafood",
        "Italian", "Mexican", "Chinese", "Japanese", "Korean", "Thai", "Indian", "French", "Greek", "Lebanese",
        "Turkish", "Spanish", "Portuguese", "Brazilian", "Argentinian", "Peruvian", "Colombian", "Venezuelan",
        "American", "Canadian", "Australian", "African", "Middle Eastern", "European", "Asian", "South American",
        "North American", "Central American", "Caribbean", "Mediterranean", "Scandinavian", "Eastern European", "Western European",
        "Central European", "Southern European", "Northern European", "Southeast Asian", "Central Asian", "Western Asian", "Southern Asian", "Northern Asian",
        "Eastern Asian", "Southeastern European", "Eastern Mediterranean", "Western Mediterranean",
        "Southern Mediterranean", "Northern Mediterranean", "Eastern African", "Western African", "Southern African", "Northern African", "Central African",
        "Eastern European", "Western European", "Southern European", "Northern European", "Southeast Asian", "Central Asian", "Western Asian", "Southern Asian",
        "Northern Asian", "Eastern Asian", "Southeastern European", "Eastern Mediterranean", "Western Mediterranean", "Southern Mediterranean", "Northern Mediterranean",
        "Eastern African", "Western African", "Southern African", "Northern African", "Central African"
    ];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Category)
            .Must(validCategpry.Contains)  
            .WithMessage("Category is not valid. Please choose from the valid category");
            // .Custom((value, context) => 
            // {
            //     if (!validCategory.Contains(value))
            //         context.AddFailure("Category is not valid. Please choose from the valid category");
            // });
        
        RuleFor(dto => dto.Name)
            .Length(3, 100).WithMessage("Name should be more than 3 characters and less than 100 characters");
        
        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Insert a valid category");
        
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Insert a valid category");
        
        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Insert a valid email address");
        
        RuleFor(dto => dto.ContactPhoneNumber)
            .Matches(@"^\d{10}$")
            .WithMessage("Insert a valid phone number");
        
        
        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{3}-\d{3}$")
            .WithMessage("Please provide a valid postal code(xxx-xxx)");
        
    }
}