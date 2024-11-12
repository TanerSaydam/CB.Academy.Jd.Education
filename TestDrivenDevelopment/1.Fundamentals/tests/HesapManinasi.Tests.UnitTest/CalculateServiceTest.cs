using HesapMakinasi;
using Xunit.Abstractions;

namespace HesapManinasi.Tests.UnitTest;
public sealed class CalculateServiceFixture
{
    public readonly CalculateService calculateService;
    public Guid Id;
    public CalculateServiceFixture()
    {
        Id = Guid.NewGuid();
        calculateService = new();
    }
}
public sealed class CalculateServiceTest : IClassFixture<CalculateServiceFixture>
{
    private readonly CalculateService _sut;
    private readonly ITestOutputHelper _output;
    private readonly CalculateServiceFixture _fixture;
    public CalculateServiceTest(CalculateServiceFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _sut = fixture.calculateService;
        _output = output;
    }

    [Fact]
    public async Task Add_ShouldSumTwoInteger_When_HaveTwoInteger()
    {
        //// Arrange
        //CalculateService calculateService = new();

        // Act
        int response = _sut.Add(1, 2);

        // Assert
        Assert.Equal(3, response);
        Assert.NotEqual(4, response);

        _output.WriteLine(_fixture.Id.ToString());

        await Task.Delay(2000);
    }

    [Fact]
    public async Task Subtract_ShouldSubtractTwoInteger_When_HaveToInteger()
    {
        int response = _sut.Subtract(3, 1);

        Assert.Equal(2, response);
        _output.WriteLine(_fixture.Id.ToString());

        await Task.Delay(2000);
    }

    [Fact]
    public async Task Divide_ShouldThrowArgumentException_When_SecondParameterValueIfZero()
    {
        Action action = () => _sut.Divide(1, 0);

        Assert.Throws<DivideException>(action);
        _output.WriteLine(_fixture.Id.ToString());

        await Task.Delay(2000);
    }

    [Fact]
    public async Task Divide_ShouldDivideTwoInteger_When_HaveTwoInteger()
    {
        int response = _sut.Divide(4, 2);
        Assert.Equal(2, response);
        _output.WriteLine(_fixture.Id.ToString());

        await Task.Delay(2000);
    }

    [Fact]
    public async Task Multiply_ShouldMultiplyTwoInteger_When_HaveTwoInteger()
    {
        int response = _sut.Multiply(2, 3);
        Assert.Equal(6, response);

        await Task.Delay(2000);
    }
}