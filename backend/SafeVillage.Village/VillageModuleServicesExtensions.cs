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
        services.AddScoped<ISequence<Building>, BuildingIdSequence>();
        services.AddScoped<ISequence<Village>, VillageIdSequence>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IHouseRepository, HouseRepository>();
        services.AddScoped<ITownHallRepository, TownHallRepository>();
        services.AddScoped<IVillageRepository, VillageRepository>();
        services.AddScoped<IDbContext>(e => new DapperContext(configuration.GetConnectionString("Village")!));

        mediatorAssemblies.Add(typeof(VillageModuleServicesExtensions).Assembly);

        return services;
    }
}
