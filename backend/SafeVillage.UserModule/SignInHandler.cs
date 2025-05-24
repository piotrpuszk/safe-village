using Ardalis.GuardClauses;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace SafeVillage.UserModule;
internal class SignInHandler(IUserRepository userRepository,
    ITokenService tokenService) : IRequestHandler<SignInCommand, SignInResult>
{
    public async Task<SignInResult> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameNoTrackingAsync(request.Username);

        user = Guard.Against.Null(user);

        var saltBytes = Convert.FromBase64String(user.PasswordSalt);
        using HMACSHA512 hmac = new(saltBytes);

        var passwordBytes = Encoding.UTF8.GetBytes(request.Password);
        var hashBytes = hmac.ComputeHash(passwordBytes);
        var hashString = Convert.ToBase64String(hashBytes);

        var isPasswordCorrect = hashString == user.PasswordHash;

        Guard.Against.Expression(e => !e, isPasswordCorrect, "invalid credentials");

        var token = tokenService.CreateToken(user);

        return new(token);
    }
}
