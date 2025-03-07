﻿using MediatR;

namespace Restaurants.Application.Users.Commands
{
    public class UpdateUseDetailsCommand :IRequest
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
    }
}
