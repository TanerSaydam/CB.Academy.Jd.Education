using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StokTakip.WebAPI.Context;
using Testcontainers.PostgreSql;

namespace StokTakip.WebAPI.Tests.IntegrationTest;
public sealed class StokTakipApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
{
    private PostgreSqlContainer postgreSqlContainer = new PostgreSqlBuilder().Build();

    public StokTakipApiFactory()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = postgreSqlContainer.GetConnectionString();
                options.UseNpgsql(connectionString);
            });
        });
    }
    public async Task InitializeAsync()
    {
        await postgreSqlContainer.StartAsync();
        string connectionString = postgreSqlContainer.GetConnectionString();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await postgreSqlContainer.DisposeAsync();
    }
}
