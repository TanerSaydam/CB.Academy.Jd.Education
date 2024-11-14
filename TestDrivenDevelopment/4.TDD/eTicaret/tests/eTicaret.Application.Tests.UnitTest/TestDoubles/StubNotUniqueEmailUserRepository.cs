using eTicaret.Domain;

namespace eTicaret.Application.Tests.UnitTest;

public class StubNotUniqueEmailUserRepository : IUserRepository
{
    public Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}
