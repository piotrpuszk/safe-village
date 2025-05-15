using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SafeVillage.Village;
public static class VillageModuleServicesExtensions
{
    public static IServiceCollection AddVillageModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        mediatorAssemblies.Add(typeof(VillageModuleServicesExtensions).Assembly);

        return services;
    }
}
