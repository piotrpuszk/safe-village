using MediatR;

namespace SafeVillage.Wilderness.Contracts;

public record DeleteWildernessCommand(int Id) : IRequest;