using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SafeVillage.Building;
public static class BuildingModuleServicesExtensions
{
    public static IServiceCollection AddBuildingModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        //services.AddScoped<IDbContext>(e => new DapperContext(configuration.GetConnectionString("building")!));

        mediatorAssemblies.Add(typeof(BuildingModuleServicesExtensions).Assembly);
        return services;
    }
}
