using eTicaret.Application;
using eTicaret.Infrastructure;
using eTicaret.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Environment.EnvironmentName, builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.MapControllers();

if (!app.Environment.IsProduction())
{
    using (var scoped = app.Services.CreateScope())
    {
        var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}

app.Run();