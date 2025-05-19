using MediatR;

namespace SafeVillage.WildernessModule.Contracts;

public record DeleteWildernessCommand(int Id) : IRequest;