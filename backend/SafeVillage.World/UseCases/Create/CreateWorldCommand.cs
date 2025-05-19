using MediatR;

namespace SafeVillage.World.UseCases.Create;

internal record CreateWorldCommand(int Width, int Height) : IRequest;
