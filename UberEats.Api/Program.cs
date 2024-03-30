using Microsoft.AspNetCore.Mvc.Infrastructure;
using UberEats.Api.Common.Errors;
using UberEats.Application;
using UberEats.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container
    builder.Services
        .AddApplicationCore()
        .AddInfrastructureCore(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, UberEatsProblemDetailsFactory>();

    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    //using minimal api instead of controller
    //app.Map("/error",(HttpContext httpContext) =>
    //{
    //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //    return Results.Problem();
    //});

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
