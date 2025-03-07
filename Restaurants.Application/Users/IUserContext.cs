namespace Restaurants.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? CurrentUser();
    }
}