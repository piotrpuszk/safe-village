using MediatR;
using SafeVillage.WildernessModule.Dtos;

namespace SafeVillage.WildernessModule.UseCases;

internal record GetQuery(int Id) : IRequest<WildernessDto>;
