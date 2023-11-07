using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services
        )
    {

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddTransient<ICustomerService, CustomerService>();

        return services;
    }
}