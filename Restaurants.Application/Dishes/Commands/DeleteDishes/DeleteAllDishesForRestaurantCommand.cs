using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

public record DeleteAllDishesForRestaurantCommand(int RestaurantId): IRequest;