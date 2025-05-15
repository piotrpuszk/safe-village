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
        services.AddScoped<IDbContext<DapperContext>>(e => new DapperContext(configuration.GetConnectionString("")!));

        mediatorAssemblies.Add(typeof(BuildingModuleServicesExtensions).Assembly);
        return services;
    }
}
