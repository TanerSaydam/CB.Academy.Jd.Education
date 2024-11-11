using FluentAssertions;

namespace TestingTechniques.Tests.UnitTest;

public class ValueSamplesTest
{
    private readonly ValueSamples _sut; //system under test

    public ValueSamplesTest()
    {
        _sut = new();
    }
    [Fact]
    public void StringAssertionExample()
    {
        // Arrange
        string fullName = _sut.FullName;

        // Assert
        //Assert.Equal("Taner Saydam", fullName);        
        fullName.Should().Be("Taner Saydam");
        fullName.Should().NotBeEmpty();
        fullName.Should().StartWith("Ta");
        fullName.Should().EndWith("m");
    }

    [Fact]
    public void NumberAssertionExample()
    {
        // Arrange
        int age = _sut.Age;

        // Assert
        age.Should().Be(35);
        age.Should().BePositive();
        age.Should().BeGreaterThan(20);
        age.Should().BeLessThanOrEqualTo(36);
        age.Should().BeInRange(20, 50);
    }

    [Fact]
    public void DateAssertionExample()
    {
        // Arrange
        DateOnly dateOfBirth = _sut.DateOfBirth;

        // Assert
        dateOfBirth.Should().Be(new(1989, 09, 03));
        dateOfBirth.Should().BeAfter(new(1980, 09, 03));
        dateOfBirth.Should().BeBefore(new(2000, 09, 03));
    }
}