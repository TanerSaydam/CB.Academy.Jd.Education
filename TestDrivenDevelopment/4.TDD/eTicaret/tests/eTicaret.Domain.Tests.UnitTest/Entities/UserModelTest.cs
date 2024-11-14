using eTicaret.Domain.Entities;
using FluentAssertions;

namespace eTicaret.Domain.Tests.UnitTest.Entities;

public class UserModelTest
{
    [Fact]
    public void FirstName_Should_Throw_Exception_If_Less_Than_3_Characters()
    {
        // Arrange
        User user = new();

        // Act
        var action = () => user.SetFirstName("Ta");

        // Assert
        action.Should().Throw<Exception>();
    }

    [Fact]
    public void FirstName_Should_Not_Throw_Exception_If_Greater_Than_2_Characters()
    {
        // Arrange
        User user = new();

        // Act
        var action = () => user.SetFirstName("Taner");

        // Assert
        action.Should().NotThrow<Exception>();
    }
}
