using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(command => command.HasDelivery).NotEmpty().WithMessage("HasDelivery is required.");
        
        //Not nullable value by default in the command so having additional validations here.
        RuleFor(command => command.Name)
            .Length(3, 100).WithMessage("Name should be more than 3 characters and less than 100 characters");
        
        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Insert a valid category");
    }
}