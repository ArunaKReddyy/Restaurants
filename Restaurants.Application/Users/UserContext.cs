using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users
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
