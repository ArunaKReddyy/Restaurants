using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;

public class GetAllRestaurantQueryHandler(ILogger<GetAllRestaurantQueryHandler> logger, IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllRestaurantQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDtos;
    }
}
