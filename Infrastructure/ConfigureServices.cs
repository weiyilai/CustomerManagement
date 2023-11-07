using Infrastructure.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<CustomerDbContext, CustomerDbContext>(_ =>
        {
            return new CustomerDbContext(configuration.GetConnectionString("Customer"));
        });

        return services;
    }
}