using MediatR;

namespace SafeVillage.WorldModule.Contracts;
public record CreateWorldCommand(int Width, int Height) : IRequest;
