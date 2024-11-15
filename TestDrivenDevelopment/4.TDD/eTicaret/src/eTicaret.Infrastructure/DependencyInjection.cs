using eTicaret.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eTicaret.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string environmentName,
        IConfiguration configuration)
    {
        if (environmentName != "Test")
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("SqlServer"));
            });
        }
        services.Scan(action => action
        .FromAssemblies(typeof(DependencyInjection).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );

        return services;
    }
}
