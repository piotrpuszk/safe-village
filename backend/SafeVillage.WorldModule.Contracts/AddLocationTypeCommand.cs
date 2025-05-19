using MediatR;

namespace SafeVillage.WorldModule.Contracts;
public record AddLocationTypeCommand(string LocationType) : IRequest;
