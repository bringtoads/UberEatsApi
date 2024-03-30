using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace UberEats.Api.Filters
{
    // Custom Exception Filter Attribute
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails 
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title= "An error occured while processing",
                Status= (int) HttpStatusCode.InternalServerError
            };
            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
