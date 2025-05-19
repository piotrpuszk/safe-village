using MediatR;

namespace SafeVillage.WorldModule.UseCases.Create;

internal record CreateWorldCommand(int Width, int Height) : IRequest;
