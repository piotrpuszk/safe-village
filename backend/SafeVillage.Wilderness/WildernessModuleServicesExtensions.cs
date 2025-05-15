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
        mediatorAssemblies.Add(typeof(WildernessModuleServicesExtensions).Assembly);

        return services;
    }
}
