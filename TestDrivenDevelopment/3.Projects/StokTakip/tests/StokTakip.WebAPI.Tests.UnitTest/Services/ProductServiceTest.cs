using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;
using StokTakip.WebAPI.Services;
using ValidationException = FluentValidation.ValidationException;

namespace StokTakip.WebAPI.Tests.UnitTest.Services;
public sealed class ProductServiceTest : IClassFixture<ProductServiceFixture>
{
    private readonly ProductServiceFixture _fixture;
    private readonly ProductService _sut;
    public ProductServiceTest(ProductServiceFixture fixture)
    {
        _fixture = fixture;
        _sut = fixture.productService;
    }

    [Fact]
    public async Task Create_Should_Throw_ValidationException_If_Name_Less_Than_3_Characters()
    {
        // Arrange
        CreateProductDto request = new("dm", 1, 1);

        // Act
        var action = async () => await _sut.CreateAsync(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.Should().HaveCount(1);
        exception.Which.Errors.First().ErrorMessage.Should().Be("Ürün adı en az 3 karakter olmalıdır");
    }

    [Fact]
    public async Task Create_Should_Throw_ValidationException_If_Stock_Less_Or_Equal_0()
    {
        // Arrange
        CreateProductDto request = new("dma", 0, 1);

        // Act
        var action = async () => await _sut.CreateAsync(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.Should().HaveCount(1);
        exception.Which.Errors.First().ErrorMessage.Should().Be("Stok adedi 0 dan büyük olmalıdır");
    }

    [Fact]
    public async Task Create_Should_Throw_ValidationException_If_Price_Less_Or_Equal_0()
    {
        // Arrange
        CreateProductDto request = new("dma", 1, 0);

        // Act
        var action = async () => await _sut.CreateAsync(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.Should().HaveCount(1);
        exception.Which.Errors.First().ErrorMessage.Should().Be("Birim fiyatı adedi 0 dan büyük olmalıdır");
    }

    [Fact]
    public async Task Create_Should_Throw_ArgumenException_If_Name_Already_Exists()
    {
        // Arrange
        CreateProductDto request = new("Bilgisayar", 1, 1);
        _fixture.productRepository
            .AnyAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
            .Returns(Task.FromResult(true));

        // Act
        var action = async () => await _sut.CreateAsync(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ArgumentException>();
        exception.Which.Message.Should().Be("Ürün adı daha önce kullanılmış");
    }

    [Fact]
    public async Task Create_Should_Convert_Dto_To_Object_If_Request_Is_Valid_And_Name_Is_Unique()
    {
        // Arrange
        CreateProductDto request = new("Bilgisayar", 1, 1);
        _fixture.productRepository
         .AnyAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
        .Returns(Task.FromResult(false));
        Product expected = new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };
        _fixture.mapper.Map<Product>(Arg.Any<CreateProductDto>()).Returns(expected);

        // Act
        var product = await _sut.CreateAsync(request, default);

        // Asert
        product.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Create_Should_Return_Product_If_Request_Is_Valid_And_Name_Is_Unique()
    {
        // Arrange
        CreateProductDto request = new("Bilgisayar", 1, 1);
        _fixture.productRepository
         .AnyAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
        .Returns(Task.FromResult(false));
        Product expected = new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };
        _fixture.mapper.Map<Product>(Arg.Any<CreateProductDto>()).Returns(expected);

        // Act
        var product = await _sut.CreateAsync(request, default);

        // Asert
        product.Should().BeEquivalentTo(expected);
        //product.Should().NotBeNull();
    }
}
