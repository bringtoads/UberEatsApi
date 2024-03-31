using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace UberEats.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}
