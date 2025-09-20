using Microsoft.Extensions.DependencyInjection;
using SocialMediaApp.Application.Interfaces;
using SocialMediaApp.Application.Services;

namespace SocialMediaApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }

}