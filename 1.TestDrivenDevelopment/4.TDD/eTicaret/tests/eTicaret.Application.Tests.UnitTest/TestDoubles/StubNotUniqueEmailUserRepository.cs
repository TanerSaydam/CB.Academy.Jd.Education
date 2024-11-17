using eTicaret.Domain;
using eTicaret.Domain.Entities;

namespace eTicaret.Application.Tests.UnitTest;

public class StubNotUniqueEmailUserRepository : IUserRepository
{
    public Task<bool> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}
