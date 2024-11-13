using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;

namespace StokTakip.WebAPI.Tests.IntegrationTest;
public sealed class ProductsEndpointTest : IClassFixture<StokTakipApiFactory>
{
    private Guid _id;
    private readonly HttpClient _httpClient;
    public ProductsEndpointTest(StokTakipApiFactory factory)
    {
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:58135");
    }

    [Fact]
    public async Task GetAll_Should_Return_StatusCode_200_When_There_Is_No_Error()
    {
        // Act
        var message = await _httpClient.GetAsync("/products");

        // Assert
        message.StatusCode.Should().Be(HttpStatusCode.OK);
        var list = await message.Content.ReadFromJsonAsync<List<Product>>();
        list.Should().NotBeNull();
    }

    [Fact]
    public async Task Create_Should_Return_StatusCode_200_If_Request_Is_Valid_And_Name_Is_Unique()
    {
        // Arrange
        Faker faker = new(); //bogus
        CreateProductDto request = new(
            faker.Commerce.ProductName(),
            faker.Random.Number(1, 20),
            Convert.ToDecimal(faker.Commerce.Price(1, 15000))
            );

        // Act
        var message = await _httpClient.PostAsJsonAsync("/products", request, default);

        // Assert
        message.StatusCode.Should().Be(HttpStatusCode.OK);
        Product? product = await message.Content.ReadFromJsonAsync<Product>();
        product.Should().NotBeNull();
        product!.Name.Should().Be(request.Name);
        _id = product.Id;
    }
}
