using Application.Services.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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
        services.AddDbContext<CustomerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Customer"))
            );

        services.AddTransient<ICustomerRepository, CustomerRepository>();
        
        return services;
    }
}