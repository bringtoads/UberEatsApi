var builder = WebApplication.CreateBuilder(args);
//Add service in  a scope
{
    // Add services to the container.
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
