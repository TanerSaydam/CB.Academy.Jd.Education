using eTicaret.Domain;
using eTicaret.Domain.Entities;
using eTicaret.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.Repositories;
internal sealed class UserRepository(
    ApplicationDbContext context) : IUserRepository
{
    public async Task<bool> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        context.Add(user);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }

    public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        var isEmailExists = await context.Users.AnyAsync(p => p.Email == email, cancellationToken);

        return isEmailExists;
    }
}
