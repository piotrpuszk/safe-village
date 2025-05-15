using MediatR;

namespace SafeVillage.World.Contracts;
public record AddLocationTypeCommand(string LocationType) : IRequest;
