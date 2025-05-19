using MediatR;

namespace SafeVillage.Wilderness.Contracts;
public record CreateWildernessCommand : IRequest<CreateWildernessResult>;
