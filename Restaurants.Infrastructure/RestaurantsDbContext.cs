using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure;

public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    public DbSet<Restaurant> Restaurants { get; set; } 
    
    public DbSet<Dish> Dishes { get; set; }

   // Setting connection string in thr file itself.
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);
        
        modelBuilder.Entity<Restaurant>()
            .HasMany(dish => dish.Dishes) // A Restaurant has many Dishes
            .WithOne() // Each Dish belongs to one Restaurant
            .HasForeignKey(dish => dish.RestaurantId); // Foreign Key is RestaurantId in the Dish table
        
    }
}