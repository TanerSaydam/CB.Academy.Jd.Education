using FluentAssertions;
using NSubstitute;

namespace TestingTechniques.Tests.UnitTest;
public sealed class UserServiceTest
{
    [Fact]
    public async Task Create_Should_Return_True_When_FullName_Is_Valid()
    {

        // Arrange
        //var moqUserService = new Mock<IUserService>();
        //moqUserService.Setup(s=> s.Create(It.IsAny<string>())).Returns(true);
        IUserService userService = Substitute.For<IUserService>();
        //userService.Create(Arg.Any<string>()).Returns(true);
        //userService.CreateAsync(Arg.Any<string>(), default).Returns(5);

        // Act
        int response = await userService.CreateAsync("Taner Saydam", default);
        //bool response = userService.Create("Taner Saydam3");
        //bool response = userService.Create("Taner Saydam5");

        // Assert
        Assert.Equal(5, response);
        response.Should().Be(5);
    }
}
