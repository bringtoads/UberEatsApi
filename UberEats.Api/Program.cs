using UberEats.Application;
using UberEats.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container
    builder.Services
        .AddApplicationCore()
        .AddInfrastructureCore(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
