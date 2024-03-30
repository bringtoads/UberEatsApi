using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Application.Common.Interfaces.Services;
using UberEats.Infrastructure.Authentication;
using UberEats.Infrastructure.Persistence;
using UberEats.Infrastructure.Services;

namespace UberEats.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureCore(
            this IServiceCollection services,
            ConfigurationManager configuration )
        {
            // adds ioptions interface where we can request jwtsettings
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
