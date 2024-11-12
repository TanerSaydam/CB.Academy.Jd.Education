using AutoFixture;
using Bogus;
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

    [Fact]
    public void ObjectAssertionExample()
    {
        Fixture fixture = new();
        User2 user2 = fixture.Create<User2>();
        Faker<User2> faker =
            new Faker<User2>()
            .RuleFor(p => p.FullName, f => f.Person.FullName)
            .RuleFor(p => p.Age, f => f.Person.Random.Number(18, 50))
            .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth);

        User2 user3 = faker.Generate();
        User2 user4 = faker.Generate();
        User2 user5 = faker.Generate();

        //user2.FullName = faker.Person.FullName;
        //user2.Age = faker.Person.Random.Number(18, 50);

        // Arrange
        User user = _sut.AppUser;
        User expected = new()
        {
            FullName = "Taner Saydam",
            Age = 35,
            DateOfBirth = new(1989, 09, 03)
        };

        // Assert
        user.Should().BeEquivalentTo(expected);
        user.FullName.Should().Be(expected.FullName);
        user.Age.Should().Be(expected.Age);
        user.DateOfBirth.Should().Be(expected.DateOfBirth);
    }

    [Fact]
    public void ListAssertionExample()
    {
        // Arrange
        IEnumerable<User> users = _sut.Users;
        List<User> expected = new()
        {
            new User()
            {
                FullName = "Taner Saydam",
                Age = 35,
                DateOfBirth= new(1989,09,03)
            },
            new User()
            {
                FullName = "Toprak Saydam",
                Age = 5,
                DateOfBirth = new(2019, 09, 07)
            }
        };

        // Assert
        users.Should().BeEquivalentTo(expected);
        users.Should().HaveCount(2);
        users.First().FullName.Should().Be(expected.First().FullName);
    }

    [Fact]
    public void InternalAssertionExample()
    {
        //Arrange 
        decimal salary = _sut.Salary;
    }
}