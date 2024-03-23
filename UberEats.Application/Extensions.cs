using Microsoft.Extensions.DependencyInjection;
using UberEats.Application.Services.Authentication;

namespace UberEats.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
