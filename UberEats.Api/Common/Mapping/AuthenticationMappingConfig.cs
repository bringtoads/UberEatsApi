using Mapster;
using UberEats.Application.Authentication.Common;
using UberEats.Contracts.Authentication;

namespace UberEats.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest , src => src.User);
        }
    }
}
