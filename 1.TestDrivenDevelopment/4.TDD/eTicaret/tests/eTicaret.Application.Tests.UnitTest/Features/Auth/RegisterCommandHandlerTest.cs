using eTicaret.Application.Tests.UnitTest.TestDoubles;
using eTicaret.Domain;
using eTicaret.Domain.Entities;
using FluentAssertions;

namespace eTicaret.Application.Tests.UnitTest;
public sealed class RegisterCommandHandlerTest
{
    [Fact]
    public async Task Register_Should_Throw_EmailNotUniqueException_If_Email_Not_Unique()
    {
        // Arrange
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");
        IUserRepository userRepository = new StubNotUniqueEmailUserRepository();
        RegisterCommandHandler handler = new(userRepository);

        // Act
        var action = async () => await handler.Handle(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<EmailNotUniqueException>();
        exception.Which.Message.Should().Be("Mail adresi daha önce kullanılmış");
    }

    [Fact]
    public async Task Register_Should_Not_Throw_Exception_If_Email_Is_Unique()
    {
        // Arrange
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");
        IUserRepository userRepository = new StubUniqueEmailUserRepository();
        RegisterCommandHandler handler = new(userRepository);

        // Act
        var action = async () => await handler.Handle(request, default);


        // Assert
        await action.Should().NotThrowAsync<Exception>();
    }

    [Fact]
    public async Task Register_Should_Convert_RegisterCommand_To_User_If_Email_Is_Unique()
    {
        // Arrange
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");
        User expected = new(request.FirstName, request.LastName, request.Email);
        IUserRepository userRepository = new StubUniqueEmailUserRepository();
        RegisterCommandHandler handler = new(userRepository);

        // Act
        var response = await handler.Handle(request, default);

        // Assert
        //response.Should().BeEquivalentTo(expected);
        response.FirstName.Should().Be(expected.FirstName);
        response.LastName.Should().Be(expected.LastName);
        response.Email.Should().Be(expected.Email);
    }

    [Fact]
    public async Task Register_Should_Return_User_If_Email_Is_Unique_And_Convert_Is_Successful()
    {
        // Arrange
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");
        User expected = new(request.FirstName, request.LastName, request.Email);
        IUserRepository userRepository = new StubUniqueEmailUserRepository();
        RegisterCommandHandler handler = new(userRepository);

        // Act
        var response = await handler.Handle(request, default);

        // Assert
        response.FirstName.Should().Be(expected.FirstName);
        response.LastName.Should().Be(expected.LastName);
        response.Email.Should().Be(expected.Email);
    }

}
