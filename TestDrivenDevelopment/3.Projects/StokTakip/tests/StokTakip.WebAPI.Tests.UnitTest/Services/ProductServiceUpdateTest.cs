using FluentAssertions;
using FluentValidation;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Services;

namespace StokTakip.WebAPI.Tests.UnitTest.Services;
public sealed class ProductServiceUpdateTest : IClassFixture<ProductServiceFixture>
{
    private readonly ProductServiceFixture _fixture;
    private readonly ProductService _sut;

    public ProductServiceUpdateTest(ProductServiceFixture fixture)
    {
        _sut = fixture.productService;
        _fixture = fixture;
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
        Guid id = Guid.Parse("c846b41a-c127-44c7-b1ae-439defc42767");
        UpdateProductDto request = new(id, "Bilgisayar", 1, 1);

        // Act
        var action = async () => await _sut.UpdateAsync(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
