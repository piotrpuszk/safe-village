using MediatR;

namespace SafeVillage.VillageModule;

internal record DeleteCommand(int Id) : IRequest;
