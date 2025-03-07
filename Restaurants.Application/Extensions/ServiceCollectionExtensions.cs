using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Application.User;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationassembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationassembly));
        services.AddAutoMapper(applicationassembly);
        services.AddValidatorsFromAssembly(applicationassembly)
            .AddFluentValidationAutoValidation();
       services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
        return services;
    }
}
