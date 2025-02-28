using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Command.CreateResatuarant;

public class CreateResaurantCommandValidator : AbstractValidator<CreateRestaurantCommad>
{
    private readonly List<string> ValidCategories = ["Italian", "Mexicon", "Chinese", "SouthIndian"];
    public CreateResaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 100);
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
        RuleFor(x => x.Category)
            .Must(ValidCategories.Contains)
            .WithMessage("Invalid category Please choose from a valid category");
        RuleFor(x => x.ContactEmailAddress)
            .EmailAddress()
            .WithMessage("Please provide valid email address");
        RuleFor(x => x.PostalCode)
           .Matches(@"^\d{2}-\d{3}")
           .WithMessage("Please provide a valid postal code(XX-XXX)");
    }
}
