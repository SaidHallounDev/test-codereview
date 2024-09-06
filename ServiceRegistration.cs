using test_codereview.Infrastructure.Contracts;
using test_codereview.Infrastructure.External.BankProvincia;
using test_codereview.Services;

namespace test_codereview;

public static class ServiceRegistration
{
    public static IServiceCollection AddServicesRegistration(this IServiceCollection services)
    {
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<IBankProvinciaClient, BankProvinciaClient>();
        return services;
    }
}
