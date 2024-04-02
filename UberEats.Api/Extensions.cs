using Microsoft.AspNetCore.Mvc.Infrastructure;
using UberEats.Api.Common.Errors;
using UberEats.Api.Common.Mapping;

namespace UberEats.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddPresentationCore(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, UberEatsProblemDetailsFactory>();
            services.AddMappingsCore();
            return services;
        }
    }
}
