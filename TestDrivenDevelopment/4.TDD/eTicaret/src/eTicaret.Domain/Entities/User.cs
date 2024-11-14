namespace eTicaret.Domain.Entities;

public sealed class User
{
    public string FirstName { get; private set; } = default!;
    public void SetName(string firstName)
    {
        if (firstName.Length < 3)
        {
            throw new Exception();
        }

        FirstName = firstName;
    }
}
