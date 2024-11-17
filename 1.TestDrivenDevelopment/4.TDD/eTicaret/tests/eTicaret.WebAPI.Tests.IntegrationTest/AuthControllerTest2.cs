using System.Net;
using System.Net.Http.Json;
using eTicaret.Application;
using FluentAssertions;

namespace eTicaret.WebAPI.Tests.IntegrationTest;
[Collection("WebApiCollection")]
public class AuthControllerTest2
{
    private HttpClient _httpClient;
    public AuthControllerTest2(ApiFactory factory)
    {
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5043");
    }

    [Fact]
    public async Task Register_Should_Return_200_Status_Code_If_Request_Is_Valid()
    {
        RegisterCommand request = new("Taner", "Saydam", "tanersaydam@gmail.com");

        // Act
        var message =
            await _httpClient
            .PostAsJsonAsync("/api/Auth/Register", request, default);

        // Assert
        message.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}