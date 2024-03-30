using System.Net;
using System.Text.Json;

namespace UberEats.Api.Middleware
{
    // Custom error handling middleware
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            //var result = JsonConvert.SerializeObject(new{ error = exception.Message}); 
            //var result = JsonSerializer.Serialize(new{ error = exception.Message});
            var result = JsonSerializer.Serialize(new{ error ="An error occured while processing"});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
