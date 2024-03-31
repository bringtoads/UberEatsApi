using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using UberEats.Application.Services.Authentication.Commands;
using UberEats.Application.Services.Authentication.Common;
using UberEats.Application.Services.Authentication.Queries;
using UberEats.Contracts.Authentication;
using UberEats.Domain.Common.Errors;

namespace UberEats.Api.Controllers
{

    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;
        public AuthenticationController(
            IAuthenticationCommandService authenticationService,
            IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {

            // using ErrorOr
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
           
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
            ////using fluent
            //if (registerResult.IsSuccess) 
            //{
            //    return Ok(MapAuthResult(registerResult.Value));
            //}
            //var firstError = registerResult.Errors[0];
            //if (firstError is DuplicateEmailError)
            //{
            //    return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists.");
            //}
            //return Problem();

            // using one of
            //Result<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            //using oneof
            //if (registerResult.IsT0)
            //{
            //    var authResult = registerResult.AsT0;
            //    var response = MapAuthResult(authResult);
            //    return Ok(response);
            //}
            //return Problem(statusCode: StatusCodes.Status409Conflict, title:"Email already exists.");

            //using pattern matching above code and this is same
            //return registerResult.Match(
            //    authResult => Ok(MapAuthResult(authResult)),
            //    _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists."));
            //return registerResult.Match(
            // authResult => Ok(MapAuthResult(authResult)),
            // error => Problem(statusCode:(int)error.StatusCode, title: "Email already exists."));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(
                request.Email,
                request.Password);
            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }
            return authResult.Match(
                         authResult => Ok(MapAuthResult(authResult)),
                         errors => Problem(errors));
        }
        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
            );
        }
    }
}
