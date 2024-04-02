using Mapster;
using UberEats.Application.Authentication.Commands.Register;
using UberEats.Application.Authentication.Common;
using UberEats.Application.Authentication.Queries.Login;
using UberEats.Contracts.Authentication;

namespace UberEats.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest , src => src.User);
        }
    }
}
