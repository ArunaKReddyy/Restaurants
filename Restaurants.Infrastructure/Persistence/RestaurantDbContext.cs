using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Restaurant> Restaurents { get; set; }

    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurentId);

        modelBuilder.Entity<User>()
           .HasMany(o => o.OwnedRestaurants)
           .WithOne(r => r.Owner)
           .HasForeignKey(r => r.OwnerId);
    }
}
