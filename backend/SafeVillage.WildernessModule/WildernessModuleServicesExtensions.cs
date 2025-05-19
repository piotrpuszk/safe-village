using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeVillage.WildernessModule.DataAccess;
using SafeVillage.WildernessModule.Domain;
using SafeVillage.WildernessModule.Interfaces;
using System.Reflection;

namespace SafeVillage.WildernessModule;
public static class WildernessModuleServicesExtensions
{
    public static IServiceCollection AddWildernessModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        services.AddScoped<IDbContext>(e => new DapperContext(configuration.GetConnectionString("Wilderness")!));
        services.AddScoped<IWildernessRepository, WildernessRepository>();
        services.AddScoped<ISequence<Wilderness>, WildernessSequence>();

        mediatorAssemblies.Add(typeof(WildernessModuleServicesExtensions).Assembly);

        return services;
    }
}
