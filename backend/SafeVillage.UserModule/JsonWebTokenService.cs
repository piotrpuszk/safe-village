using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SafeVillage.UserModule;

internal class JsonWebTokenService(IConfiguration configuration) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        string tokenKey = Guard.Against.NullOrEmpty(configuration["TokenKey"]);
        tokenKey = Guard.Against.LengthOutOfRange(tokenKey, 64, int.MaxValue);
        var tokenKeyBytes = Encoding.UTF8.GetBytes(tokenKey);
        var key = new SymmetricSecurityKey(tokenKeyBytes);

        Claim[] claims = [new(ClaimTypes.NameIdentifier, user.Username)];

        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor descriptor = new()
        {
            Subject = new(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials,
        };

        JwtSecurityTokenHandler handler = new();
        var token = handler.CreateToken(descriptor);

        return handler.WriteToken(token);
    }
}