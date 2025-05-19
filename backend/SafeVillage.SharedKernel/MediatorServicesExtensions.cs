using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SafeVillage.SharedKernel;
public static class MediatorServicesExtensions
{
    public static IServiceCollection AddHandlerLoggingBehavior(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MediatorHandlerLoggingBehavior<,>));

        return services;
    }
}
