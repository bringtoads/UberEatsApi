using UberEats.Api;
using UberEats.Application;
using UberEats.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container
    builder.Services
        .AddPresentationCore()
        .AddApplicationCore()
        .AddInfrastructureCore(builder.Configuration);

}

var app = builder.Build();
{
    //request pipeline(middlewares)
    app.UseExceptionHandler("/error");
    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    //app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
