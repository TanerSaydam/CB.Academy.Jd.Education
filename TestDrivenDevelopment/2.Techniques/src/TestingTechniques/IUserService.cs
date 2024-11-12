namespace TestingTechniques;
public interface IUserService
{
    bool Create(string fullName);
    Task<int> CreateAsync(string fullName, CancellationToken cancellationToken);
}

public class UserService : IUserService
{
    public bool Create(string fullName)
    {
        return false;
    }

    public Task<int> CreateAsync(string fullName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
