using Ardalis.GuardClauses;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace SafeVillage.UserModule;
internal class SignUpHandler(IUserRepository userRepository) : IRequestHandler<SignUpCommand>
{
    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        using HMACSHA512 hmac = new();

        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        var saltBytes = hmac.Key;
        
        var hashString = Convert.ToBase64String(hashBytes);
        var saltString = Convert.ToBase64String(saltBytes);

        AppUser user = AppUser.Create
            (
                request.Username,
                hashString,
                saltString,
                []
            );

        await userRepository.AddAsync(user);

        var affectedRows = await userRepository.SaveChangesAsync();

        Guard.Against.Zero(affectedRows);
    }
}
