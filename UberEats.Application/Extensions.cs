using Microsoft.Extensions.DependencyInjection;
using UberEats.Application.Services.Authentication.Commands;
using UberEats.Application.Services.Authentication.Queries;

namespace UberEats.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            return services;
        }
    }
}
