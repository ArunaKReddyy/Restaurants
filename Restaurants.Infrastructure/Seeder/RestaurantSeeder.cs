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

    private List<Restaurant> GetRestaurants()
    {
        return new List<Restaurant>
     {
        new Restaurant
        {
            Name = "Italian Bistro",
            Description = "A cozy place for Italian cuisine.",
            Category = "Italian",
            IsDelivery = true,
            ContactEmailAddress = "contact@italianbistro.com",
            ContactPhoneNumber = "123-456-7890",
            Address = new Address
            {
                City = "New York",
                Street = "123 Main St",
                PostalCode = "10001"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Spaghetti Carbonara",
                    Description = "Classic Italian pasta dish.",
                    Price = 12.99m,
                    KiloCalories = 800
                },
                new Dish
                {
                    Name = "Margherita Pizza",
                    Description = "Traditional pizza with tomatoes, mozzarella, and basil.",
                    Price = 10.99m,
                    KiloCalories = 700
                }
            }
        },
        new Restaurant
        {
            Name = "Sushi Place",
            Description = "Fresh and delicious sushi.",
            Category = "Japanese",
            IsDelivery = false,
            ContactEmailAddress = "info@sushiplace.com",
            ContactPhoneNumber = "987-654-3210",
            Address = new Address
            {
                City = "San Francisco",
                Street = "456 Market St",
                PostalCode = "94105"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "California Roll",
                    Description = "Crab, avocado, and cucumber roll.",
                    Price = 8.99m,
                    KiloCalories = 300
                },
                new Dish
                {
                    Name = "Spicy Tuna Roll",
                    Description = "Tuna with spicy mayo.",
                    Price = 9.99m,
                    KiloCalories = 350
                }
            }
        }
    };
  }
}
