using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UberEats.Application.Common.Interfaces.Authentication;
using UberEats.Application.Common.Interfaces.Services;
using UberEats.Domain.Entities;

namespace UberEats.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;
        public JwtTokenGenerator(
            IDateTimeProvider dateTimeProvider,
            IOptions<JwtSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }
        public string GenerateToken(User user)
        {
            // using a symmetric key 
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims : claims,
                signingCredentials : signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
        // generate a 256-bit key 
        private string Base64KeyGenerator()
        {
            // 256 bit = 32 bytes  ;
            byte[] key = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            var test = Convert.ToBase64String(key);
            return test;
            //return Convert.ToBase64String(key);
        }
    }
}
