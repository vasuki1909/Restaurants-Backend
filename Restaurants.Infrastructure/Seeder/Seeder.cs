using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Seeder;

public class Seeder(RestaurantsDbContext dbContext) : ISeeder
{
    public async Task Seed()
    {
        //check if we are able to connect to db
        if(await dbContext.Database.CanConnectAsync())
        {
            if(!dbContext.Restaurants.Any() && !dbContext.Dishes.Any())
            {
                var restaurants = new List<Restaurant>
                {
                    new ()
                    {
                        Name = "KFC",
                        Description = "KFC Description",
                        Address = new Address
                        {
                            City = "KFC City",
                            Street = "KFC Street",
                            PostalCode = "KFC ZipCode"
                        },
                         Category = "Fast food",
                         HasDelivery = true,
                         ContactEmail = "KFC Email",
                         Dishes = [ new Dish { Name = "Chicken wings", Price = 300.99m, Description =  "Chicken wings Description" }, 
                             new Dish { Name = "Burger", Description = "Burger description", Price = 199m} ]
                    },
                    new ()
                    {
                        Name = "McDonalds",
                        Description = "McDonalds Description",
                        Address = new Address()
                        {
                            City = "McDonalds City",
                            Street = "McDonalds Street",
                            PostalCode = "McDonalds ZipCode"
                        },
                        Category = "Fast food",
                        HasDelivery = false,
                        ContactEmail = "McDonalds Email",
                        ContactPhoneNumber = "McDonalds Phone"
                    }
                };

                await dbContext.Restaurants.AddRangeAsync(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}