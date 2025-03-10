using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;

public class GetAllRestaurantQueryHandler(ILogger<GetAllRestaurantQueryHandler> logger, IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllRestaurantQuery, PagedResult
    <RestaurantDto>>
{
    public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Restaurants");

        var (restaurants,count) = await restaurantRepository.GetAllMatchingAsync(request.SearchPhrase!,request.PageNumber,request.PageSize);
        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        var pagedResult = new PagedResult<RestaurantDto>(restaurantsDtos, count,request.PageNumber,request.PageSize);

        return pagedResult;
    }
}
