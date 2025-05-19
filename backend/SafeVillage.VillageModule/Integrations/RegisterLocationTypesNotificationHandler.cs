using MediatR;
using SafeVillage.WorldModule.Contracts;

namespace SafeVillage.VillageModule.Integrations;
internal class RegisterLocationTypesNotificationHandler(IMediator mediator) : INotificationHandler<RegisterLocationTypesNotification>
{
    public async Task Handle(RegisterLocationTypesNotification notification, CancellationToken cancellationToken)
    {
        await mediator.Send(new AddLocationTypeCommand(Constants.LocationType), cancellationToken);
    }
}