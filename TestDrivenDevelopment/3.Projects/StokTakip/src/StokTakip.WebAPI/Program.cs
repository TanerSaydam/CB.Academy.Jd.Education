using GenericRepository;
using Microsoft.EntityFrameworkCore;
using StokTakip.WebAPI.Context;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

if (!builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("NpgSql"));
    });
}

builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/products", async (IProductService productService, CancellationToken cancellationToken) =>
{
    var products = await productService.GetAllAsync(cancellationToken);
    return products;
});

app.MapGet("/products/{id}", async (Guid id, IProductService productService, CancellationToken cancellationToken) =>
{
    var product = await productService.GetByIdAsync(id, cancellationToken);
    return product;
});

app.MapPost("/products", async (CreateProductDto request, IProductService productService, CancellationToken cancellationToken) =>
{
    var product = await productService.CreateAsync(request, cancellationToken);
    return product;
});

app.MapPut("/products", async (UpdateProductDto request, IProductService productService, CancellationToken cancellationToken) =>
{
    var product = await productService.UpdateAsync(request, cancellationToken);
    return product;
});

app.MapDelete("/products", async (Guid id, IProductService productService, CancellationToken cancellationToken) =>
{
    var result = await productService.DeleteByIdAsync(id, cancellationToken);
    return Results.Ok();
});

using (var scoped = app.Services.CreateScope())
{
    var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
