using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SafeVillage.UserModule;
public static class UserModuleServicesExtensions
{
    public static IServiceCollection AddUserModuleServices(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatorAssemblies)
    {
        string connectionString = configuration.GetConnectionString("User")!;
        services.AddDbContext<UserContext>(e => e.UseNpgsql(connectionString));
        services.AddScoped<ITokenService, JsonWebTokenService>();
        services.AddScoped<IUserRepository, UserRepository>();

        mediatorAssemblies.Add(typeof(UserModuleServicesExtensions).Assembly);

        return services;
    }
}
