using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Restaurants;

internal class RestaurantRepository(RestaurantDbContext dbContext) : IRestaurantRepository
{
    public async Task<int> CreateRestaurant(Restaurant restaurant)
    {
        await dbContext.Restaurents.AddAsync(restaurant);
        dbContext.SaveChanges();
        return restaurant.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
         return await dbContext.Restaurents.Include(x => x.Dishes).ToListAsync();
    }

    public async Task<Restaurant?> GetById(int id)
    {
        return await dbContext.Restaurents.Include(x=>x.Dishes).FirstOrDefaultAsync(x=>x.Id== id);
    }
    public async Task Delete(Restaurant entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
    public Task SaveChanges()
    => dbContext.SaveChangesAsync();
}
