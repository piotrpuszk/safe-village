using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeVillage.WorldModule.DataAccess;
using SafeVillage.WorldModule.Domain;
using SafeVillage.WorldModule.Interfaces;
using System.Reflection;

namespace SafeVillage.WorldModule;
public static class WorldModuleServicesExtensions
{
    public static IServiceCollection AddWorldModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatrAssemblies)
    {
        services.AddScoped<IWorldRepository, WorldRepository>();
        services.AddScoped<IDbContext>(e => new DapperContext(configuration.GetConnectionString("World")!));


        mediatrAssemblies.Add(typeof(WorldModuleServicesExtensions).Assembly);

        return services;
    }
}
