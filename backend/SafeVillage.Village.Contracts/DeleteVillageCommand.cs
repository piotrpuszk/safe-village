using MediatR;

namespace SafeVillage.Village.Contracts;
public record DeleteVillageCommand(int VillageId) : IRequest;