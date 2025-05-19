using MediatR;

namespace SafeVillage.VillageModule.Contracts;
public record CreateVillageCommand(string Name) : IRequest<CreateVillageResult>;