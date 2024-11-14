using eTicaret.Domain;

namespace eTicaret.Application.Tests.UnitTest.TestDoubles;

public class StubUniqueEmailUserRepository : IUserRepository
{
    public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return false;
    }
}
