using MediatR;

namespace SafeVillage.World;

internal record CreateWorldCommand(int Width, int Height) : IRequest;
