using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net.WebSockets;
using UberEats.Application.Authentication.Commands.Register;
using UberEats.Application.Authentication.Common;
using UberEats.Application.Authentication.Queries.Login;
using UberEats.Contracts.Authentication;
using UberEats.Domain.Common.Errors;
using UberEats.Domain.User.ValueObjects;

namespace UberEats.Api.Controllers
{

    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            //if (authResult.Value.User != null)
            //{
            //    var id = UserId.Create(authResult.Value.User.Id.Value);
            //    var firstName = authResult.Value.User.FirstName;
            //    var lastName = authResult.Value.User.LastName;
            //    var email = authResult.Value.User.Email;
            //    var password = authResult.Value.User.Password;
            //    var token = authResult.Value.Token;
            //    var result = new AuthenticationResponse(id.Value,firstName,lastName,email, token);
            //    return Ok(result);
            //}
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }
            return authResult.Match(
                         authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                         errors => Problem(errors));
        }
    }
}
