using FastEndpoints;
using Mapster;
using MediatR;
using System.Security.Claims;

namespace SafeVillage.UserModule.Endpoints;
internal class GetLoggedUser(IMediator mediator) : EndpointWithoutRequest<GetLoggedUserResponse>
{
    public override void Configure()
    {
        Get("/api/users/logged-user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var username = HttpContext.User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;

        GetUserQuery query = new(username);

        var result = await mediator.Send(query, ct);

        var response = result.Adapt<GetLoggedUserResponse>();

        await SendOkAsync(response, ct);
    }
}
