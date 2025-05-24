using MediatR;

namespace SafeVillage.UserModule;

internal record GetUserQuery(string Username) : IRequest<GetUserResult>;
