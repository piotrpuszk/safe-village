using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SafeVillage.Wilderness;
public static class WildernessModuleServicesExtensions
{
    public static IServiceCollection AddWildernessModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        services.AddScoped<IDbContext>(e => new DapperContext(configuration.GetConnectionString("Wilderness")!));
        services.AddScoped<IWildernessRepository, WildernessRepository>();
        services.AddSingleton<ISequence<Wilderness>, WildernessSequence>();

        mediatorAssemblies.Add(typeof(WildernessModuleServicesExtensions).Assembly);

        return services;
    }
}
