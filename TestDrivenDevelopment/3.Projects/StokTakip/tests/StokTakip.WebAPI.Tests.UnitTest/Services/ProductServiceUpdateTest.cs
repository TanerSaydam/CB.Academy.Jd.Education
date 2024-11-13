using System.Linq.Expressions;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;
using StokTakip.WebAPI.Services;

namespace StokTakip.WebAPI.Tests.UnitTest.Services;
public sealed class ProductServiceUpdateTest : IClassFixture<ProductServiceFixture>
{
    private readonly ProductServiceFixture _fixture;
    private readonly ProductService _sut;
    private readonly Guid _id;
    private readonly UpdateProductDto _request;
    private readonly Product _expected;
    private readonly Product _product;
    public ProductServiceUpdateTest(ProductServiceFixture fixture)
    {
        _sut = fixture.productService;
        _fixture = fixture;
        _id = Guid.Parse("c846b41a-c127-44c7-b1ae-439defc42767");
        _request = new(_id, "Bilgisayar", 1, 1);
        _expected = new()
        {
            Id = _id,
            Name = "Bilgisayar",
            Stock = 1,
            Price = 1
        };
        _product = new()
        {
            Id = _id,
            Name = "Computer",
            Stock = 1,
            Price = 1
        };
    }

    [Fact]
    public async Task Update_Should_Throw_ValidationException_If_Name_Less_Than_3_Characters()
    {
        // Arrange
        UpdateProductDto request = new(Guid.NewGuid(), "pd", 1, 1);

        // Act
        var action = async () => await _sut.UpdateAsync(request, CancellationToken.None);

        // Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.First().ErrorMessage.Should().Contain("Ürün");
        exception.Which.Errors.Should().HaveCount(1);
    }

    [Fact]
    public async Task Update_Should_Throw_ValidationException_If_Stock_Less_Or_Equal_Zero()
    {
        // Arrange
        UpdateProductDto request = new(Guid.NewGuid(), "pda", 0, 1);

        // Act
        var action = async () => await _sut.UpdateAsync(request, CancellationToken.None);

        // Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.First().ErrorMessage.Should().Contain("Stok");
        exception.Which.Errors.Should().HaveCount(1);
    }

    [Fact]
    public async Task Update_Should_Throw_ValidationException_If_Price_Less_Or_Equal_Zero()
    {
        // Arrange
        UpdateProductDto request = new(Guid.NewGuid(), "pda", 1, 0);

        // Act
        var action = async () => await _sut.UpdateAsync(request, CancellationToken.None);

        // Assert
        var exception = await action.Should().ThrowAsync<ValidationException>();
        exception.Which.Errors.First().ErrorMessage.Should().Contain("Birim fiyatı");
        exception.Which.Errors.Should().HaveCount(1);
    }

    [Fact]
    public async Task Update_Should_Throw_ArgumentNullException_If_Product_Cannot_Find()
    {
        // Arrange 
        _fixture.productRepository
            .FirstOrDefaultAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
            .ReturnsNull();

        // Act
        var action = async () => await _sut.UpdateAsync(_request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task Update_Should_Throw_ArgumentException_If_Name_Already_Exists()
    {
        // Arrange
        _fixture.productRepository
            .FirstOrDefaultAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
            .Returns(_product);
        _fixture.productRepository
            .AnyAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
            .Returns(true);

        // Act
        var action = async () => await _sut.UpdateAsync(_request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ArgumentException>();
        exception.Which.Message.Should().Be("Ürün adı daha önce kullanılmış");
    }

    //[Fact]
    //public async Task Update_Should_Convert_Dto_To_Object_If_Request_Is_Valid_And_Name_Is_Unique()
    //{
    //    // Arrange
    //    _fixture.productRepository
    //        .FirstOrDefaultAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
    //        .Returns(_product);
    //    _fixture.productRepository
    //        .AnyAsync(Arg.Any<Expression<Func<Product, bool>>>(), default)
    //        .Returns(false);
    //    _fixture.mapper
    //    .Map(_product, _request)
    //    .Returns(_request);

    //    // Act
    //    var result = await _sut.UpdateAsync(_request, default);

    //    // Assert
    //    result.Should().BeEquivalentTo(_expected);
    //}
}
