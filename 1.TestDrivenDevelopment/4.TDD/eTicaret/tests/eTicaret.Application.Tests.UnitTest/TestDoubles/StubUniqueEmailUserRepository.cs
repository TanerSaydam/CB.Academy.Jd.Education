using eTicaret.Domain;
using eTicaret.Domain.Entities;

namespace eTicaret.Application.Tests.UnitTest.TestDoubles;

public class StubUniqueEmailUserRepository : IUserRepository
{
    public Task<bool> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return false;
    }
}
