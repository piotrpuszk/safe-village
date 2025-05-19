using MediatR;

namespace SafeVillage.WildernessModule.Contracts;
public record CreateWildernessCommand : IRequest<CreateWildernessResult>;
