using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.CreateResatuarant;

public class CreateRestaurantCommadHandler(
    ILogger logger,IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurantCommad, int>
{
    public async Task<int> Handle(CreateRestaurantCommad request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating Restaurant");
        var restaurant = mapper.Map<Restaurant>(request);
        var id = await restaurantRepository.CreateRestaurant(restaurant);
        return id;
    }
}
