using MediatR;
using SafeVillage.WaterModule.Dtos;

namespace SafeVillage.WaterModule.UseCases;

internal record GetQuery(int Id) : IRequest<WaterDto>;
