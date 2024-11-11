using GenericRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StokTakip.WebAPI.Context;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Services;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("MyDb");
});

builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/getall", async (IProductService productService, CancellationToken cancellationToken) =>
{
    var products = await productService.GetAllAsync(cancellationToken);
    return products;
});

app.MapGet("/getbyid", async (Guid id, IProductService productService, CancellationToken cancellationToken) =>
{
    var product = await productService.GetByIdAsync(id, cancellationToken);
    return product;
});

app.MapPost("/create", async (CreateProductDto request, IProductService productService, CancellationToken cancellationToken) =>
{
    var product = await productService.CreateAsync(request, cancellationToken);
    return product;
});

app.MapPut("/update", async (UpdateProductDto request, IProductService productService, CancellationToken cancellationToken) =>
{
    var product = await productService.UpdateAsync(request, cancellationToken);
    return product;
});

app.MapDelete("/deletebyid", async (Guid id, IProductService productService, CancellationToken cancellationToken) =>
{
    var result = await productService.DeleteByIdAsync(id, cancellationToken);
    return Results.Ok();
});

app.Run();
