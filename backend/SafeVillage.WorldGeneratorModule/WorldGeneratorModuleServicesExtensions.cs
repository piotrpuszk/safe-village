using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SafeVillage.WorldGeneratorModule;
public static class WorldGeneratorModuleServicesExtensions
{
    public static IServiceCollection AddWorldGeneratorModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        mediatorAssemblies.Add(typeof(WorldGeneratorModuleServicesExtensions).Assembly);

        return services;
    }
}
