using MediatR;

namespace SafeVillage.UserModule;

internal record SignInCommand(string Username, string Password) : IRequest<SignInResult>;
