using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeVillage.WaterModule.DataAccess;
using SafeVillage.WaterModule.Domain;
using SafeVillage.WaterModule.Interfaces;
using System.Reflection;

namespace SafeVillage.WaterModule;
public static class WaterModuleServicesExtensions
{
    public static IServiceCollection AddWaterModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        services.AddScoped<IDbContext>(e => new DapperContext(configuration.GetConnectionString("Water")!));
        services.AddScoped<IWaterRepository, WaterRepository>();
        services.AddScoped<ISequence<Water>, WaterSequence>();

        mediatorAssemblies.Add(typeof(WaterModuleServicesExtensions).Assembly);

        return services;
    }
}
