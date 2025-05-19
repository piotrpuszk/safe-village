using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeVillage.World.DataAccess;
using SafeVillage.World.Domain;
using SafeVillage.World.Interfaces;
using System.Reflection;

namespace SafeVillage.World;
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
