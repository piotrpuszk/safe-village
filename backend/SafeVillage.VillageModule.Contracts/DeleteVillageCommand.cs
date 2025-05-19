using MediatR;

namespace SafeVillage.VillageModule.Contracts;
public record DeleteVillageCommand(int VillageId) : IRequest;