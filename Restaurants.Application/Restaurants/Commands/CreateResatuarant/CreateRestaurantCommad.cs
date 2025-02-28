using MediatR;

namespace Restaurants.Application.Restaurants.Command.CreateResatuarant;

public class CreateRestaurantCommad :IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;

    public bool IsDelivery { get; set; }

    public string? ContactEmailAddress { get; set; }
    public string? ContactPhoneNumber { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
}
