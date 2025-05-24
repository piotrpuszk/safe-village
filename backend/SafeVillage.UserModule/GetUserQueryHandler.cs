using Mapster;
using MediatR;

namespace SafeVillage.UserModule;
internal class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, GetUserResult>
{
    public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameNoTrackingAsync(request.Username);

        UserDto userDto = user.Adapt<UserDto>();

        return new(userDto);
    }
}
