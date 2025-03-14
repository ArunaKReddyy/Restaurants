﻿namespace Restaurants.Application.Users
{
    public record CurrentUser(string UserId, string Email, IEnumerable<string> Roles)
    {
        public bool IsInRoles(string role) => Roles.Contains(role);
    }
}
