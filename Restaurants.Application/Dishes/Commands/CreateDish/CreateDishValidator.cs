using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishValidator: AbstractValidator<CreateDishCommand>
{
    public CreateDishValidator()
    {
        RuleFor(d => d.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to zero.");
        RuleFor(d => d.KiloCalories).GreaterThanOrEqualTo(0).When(d=> d.KiloCalories.HasValue).WithMessage("Calories must be greater than or equal to zero.");
    }
}