using System.Net;
using System.Net.Http.Json;
using eTicaret.Application;
using FluentAssertions;

namespace eTicaret.WebAPI.Tests.IntegrationTest;

public class AuthControlletTest
{
    [Fact]
    public async Task Register_Should_Return_200_Status_Code_If_Request_Is_Valid()
    {
        // Arrange
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5043")
        };
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");

        // Act
        var message =
            await httpClient
            .PostAsJsonAsync("/api/Auth/Register", request, default);

        // Assert
        message.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}