using MediatR;

namespace SafeVillage.VillageModule.UseCases.Delete;

internal record DeleteCommand(int Id) : IRequest;
