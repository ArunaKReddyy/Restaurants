using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryValidator : AbstractValidator<GetAllRestaurantQuery>
    {
        private int[] allowedPageSizes = [5, 10, 15, 30];

        private string[] allowedSortByColumnNames = { nameof(RestaurantDto.Name),
        nameof(RestaurantDto.Description),nameof(RestaurantDto.Category)};
        public GetAllRestaurantQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize)
                .Must(x => allowedPageSizes.Contains(x))
                .WithMessage($"Page size must be in {string.Join(",",allowedPageSizes)}");
        }
    }
}
