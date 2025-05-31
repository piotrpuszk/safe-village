using Mapster;
using MediatR;
using SafeVillage.WaterModule.Dtos;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.UseCases;

internal class GetQueryHandler(IWaterRepository waterRepository) : IRequestHandler<GetQuery, WaterDto>
{
    public async Task<WaterDto> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var water = await waterRepository.GetAsync(request.Id);

        return water.Adapt<WaterDto>();
    }
}
