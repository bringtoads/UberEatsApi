using Microsoft.Extensions.DependencyInjection;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Infrastructure.Authentication;

namespace UberEats.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureCore(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
