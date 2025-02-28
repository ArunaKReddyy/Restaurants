using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantsById;

public class GetRestaurantsByIdQueryHandler(
    ILogger logger, IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantsByIdQuery, RestaurantDto>
{
    public  async Task<RestaurantDto?> Handle(GetRestaurantsByIdQuery request, CancellationToken cancellationToken)
    {
            logger.LogInformation($"Getting Restaurant {request.Id}");
            var restaurant = await restaurantRepository.GetById(request.Id);
            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
            return restaurantDto;
    }
}
