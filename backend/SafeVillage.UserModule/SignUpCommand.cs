using MediatR;

namespace SafeVillage.UserModule;

internal record SignUpCommand(string Username, string Password) : IRequest;
