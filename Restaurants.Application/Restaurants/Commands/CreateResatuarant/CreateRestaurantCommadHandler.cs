using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.CreateResatuarant;

public class CreateRestaurantCommadHandler(
    ILogger<CreateRestaurantCommadHandler> logger,IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating Restaurant{@Restaurant}", request);
        var restaurant = mapper.Map<Restaurant>(request);
        var id = await restaurantRepository.CreateRestaurant(restaurant);
        return id;
    }
}
