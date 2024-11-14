using eTicaret.Domain;
using eTicaret.Domain.Entities;
using MediatR;

namespace eTicaret.Application;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email) : IRequest<User>;

public sealed class RegisterCommandHandler(
    IUserRepository userRepository) : IRequestHandler<RegisterCommand, User>
{
    public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExists = await userRepository.IsEmailExistsAsync(request.Email, cancellationToken);
        if (isEmailExists)
        {
            throw new EmailNotUniqueException();
        }

        User user = MapToUser(request);

        var result = await userRepository.AddAsync(user, cancellationToken);

        if (!result)
        {
            throw new Exception();
        }

        return user;
    }

    public User MapToUser(RegisterCommand request)
    {
        return new User(request.FirstName, request.LastName, request.Email);
    }

}
