namespace eTicaretServer;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;
    public static IServiceCollection AddServiceTool(this IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
