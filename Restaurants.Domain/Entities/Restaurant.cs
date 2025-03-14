﻿namespace Restaurants.Domain.Entities;

public class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;

    public bool IsDelivery { get; set; }
    public string? ContactEmailAddress { get; set; } 
    public string? ContactPhoneNumber { get; set; }
    public Address? Address { get; set; }
    public List<Dish> Dishes { get; set; } = [];
    public User Owner { get; set; } = default!;
    public string OwnerId { get; set; } = default!;
    public string? LogoUrl { get; set; }
}

