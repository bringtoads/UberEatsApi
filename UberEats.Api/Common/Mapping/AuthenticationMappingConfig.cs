using Mapster;
using UberEats.Application.Authentication.Commands.Register;
using UberEats.Application.Authentication.Common;
using UberEats.Application.Authentication.Queries.Login;
using UberEats.Contracts.Authentication;
using UberEats.Domain.User.ValueObjects;

namespace UberEats.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.ID, src => UserId.Create(src.User.Id.Value).Value)
            .Map(dest => dest.FirstName , src => src.User.FirstName)
            .Map(dest => dest.LastName , src => src.User.LastName)
            .Map(dest => dest.Email , src => src.User.Email);
        }
    }
}
