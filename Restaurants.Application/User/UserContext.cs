using Microsoft.AspNetCore.Http;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? CurrentUser()
        {
            var User = (httpContextAccessor?.HttpContext?.User) ?? throw new InvalidOperationException("User not found");

            if (User.Identity?.IsAuthenticated != true)
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }

            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Email = User.FindFirstValue(ClaimTypes.Email);
            return new CurrentUser(UserId!, Email!, roles);
        }
    }
}
