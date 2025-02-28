using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeder;

internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seeder()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurents.Any())
            {
                var resataurnats = GetRestaurants();
                dbContext.AddRange(resataurnats);
                dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        var dish1 = new Dish
        {
            Id = 1,
            Name = "Pizza Margherita",
            Description = "Classic Italian pizza with tomato, mozzarella, and basil.",
            Price = 12.99m,
            RestaurentId = 1
        };

        var dish2 = new Dish
        {
            Id = 2,
            Name = "Spaghetti Carbonara",
            Description = "Spaghetti with eggs, cheese, pancetta, and pepper.",
            Price = 14.99m,
            RestaurentId = 1
        };

        var dish3 = new Dish
        {
            Id = 3,
            Name = "Tacos",
            Description = "Soft tortillas filled with seasoned beef, lettuce, cheese, and salsa.",
            Price = 9.99m,
            RestaurentId = 2
        };

        var restaurants = new List<Restaurant>
        {
            new()
        {
            Id = 1,
            Name = "Italian Bistro",
            Description = "A cozy Italian restaurant serving authentic pasta and pizza.",
            Category = "Italian",
            IsDelivery = true,
            ContactEmailAddress = "contact@italianbistro.com",
            ContactPhoneNumber = "+1 555-1234",
            Address = new Address
            {
                City = "New York",
                Street = "5th Avenue",
                PostalCode = "10001",
            },
            Dishes = new List<Dish> { dish1, dish2 }
        },
        new()
        {
            Id = 2,
            Name = "Mexican Fiesta",
            Description = "A lively Mexican restaurant with tacos, burritos, and margaritas.",
            Category = "Mexican",
            IsDelivery = false,
            ContactEmailAddress = "contact@mexicanfiesta.com",
            ContactPhoneNumber = "+1 555-5678",
            Address = new Address
            {
                City = "New York",
                Street = "5th Avenue",
                PostalCode = "10001",
            },
            Dishes = new List<Dish> { dish3 }
        }
        };
        return restaurants;
    }
}
