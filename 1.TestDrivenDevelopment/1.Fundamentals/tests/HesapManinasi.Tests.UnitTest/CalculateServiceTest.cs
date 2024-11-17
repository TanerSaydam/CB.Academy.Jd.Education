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
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { 1,2,3},
        new object[] { 2,2,4},
        new object[] { 3,2,5},
    };

    private readonly CalculateService _sut;
    private readonly ITestOutputHelper _output;
    private readonly CalculateServiceFixture _fixture;
    public CalculateServiceTest(CalculateServiceFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _sut = fixture.calculateService;
        _output = output;
    }

    [Theory]
    //[InlineData(1, 2, 3)]
    //[InlineData(4, 2, 6)]
    //[InlineData(8, 3, 11)]
    [MemberData(nameof(Data))]
    public void Add_ShouldSumTwoInteger_When_HaveTwoInteger(int x, int y, int expected)
    {
        //// Arrange
        //CalculateService calculateService = new();

        // Act
        int response = _sut.Add(x, y);

        // Assert
        Assert.Equal(expected, response);
        Assert.NotEqual(expected + 1, response);

        //_output.WriteLine(_fixture.Id.ToString());

        //await Task.Delay(2000);
    }

    [Fact]
    public async Task Subtract_ShouldSubtractTwoInteger_When_HaveToInteger()
    {
        int response = _sut.Subtract(3, 1);

        Assert.Equal(2, response);
        _output.WriteLine(_fixture.Id.ToString());

        await Task.Delay(2000);
    }

    //[Fact(Skip = "Bu test çalışmamalı")]
    [Fact]
    public async Task Divide_ShouldThrowArgumentException_When_SecondParameterValueIfZero()
    {
        Action action = () => _sut.Divide(1, 0);

        Assert.Throws<DivideException>(action);
        _output.WriteLine(_fixture.Id.ToString());

        await Task.Delay(2000);
    }

    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(4, 0, 0, Skip = "ikinci rakam 0a bölünemediği için bu test çalışmamalı")]
    public void Divide_ShouldDivideTwoInteger_When_HaveTwoInteger(int x, int y, int expected)
    {
        int response = _sut.Divide(x, y);
        Assert.Equal(expected, response);
        //_output.WriteLine(_fixture.Id.ToString());

        //await Task.Delay(2000);
    }

    [Fact]
    public async Task Multiply_ShouldMultiplyTwoInteger_When_HaveTwoInteger()
    {
        int response = _sut.Multiply(2, 3);
        Assert.Equal(6, response);

        await Task.Delay(2000);
    }

}


