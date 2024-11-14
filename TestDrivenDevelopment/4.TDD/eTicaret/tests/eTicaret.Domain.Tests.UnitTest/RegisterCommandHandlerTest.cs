using FluentAssertions;

namespace eTicaret.Domain.Tests.UnitTest;
public sealed class RegisterCommandHandlerTest
{
    [Fact]
    public async Task Register_Should_Throw_EmailNotUniqueException_If_Email_Not_Unique()
    {
        // Arrange
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");
        RegisterCommandHandler handler = new();

        // Act
        var action = async () => await handler.Handle(request, default);

        // Assert
        var exception = await action.Should().ThrowAsync<EmailNotUniqueException>();
        exception.Which.Message.Should().Be("Mail adresi daha önce kullanılmış");
    }
}

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email);

public sealed class RegisterCommandHandler
{
    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new EmailNotUniqueException();
    }
}

public sealed class EmailNotUniqueException : Exception
{
    public EmailNotUniqueException() : base("Mail adresi daha önce kullanılmış")
    {

    }

    //public implicit operator
}
