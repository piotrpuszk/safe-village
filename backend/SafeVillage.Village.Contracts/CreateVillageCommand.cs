using MediatR;

namespace SafeVillage.Village.Contracts;
public record CreateVillageCommand(string Name) : IRequest<CreateVillageResult>;