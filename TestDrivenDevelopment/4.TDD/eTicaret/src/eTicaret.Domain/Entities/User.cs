namespace eTicaret.Domain.Entities;

public sealed class User
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public User()
    {

    }
    public User(string firstName, string lastName, string email)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
    }

    public void SetFirstName(string firstName)
    {
        if (firstName.Length < 3)
        {
            throw new Exception();
        }

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (lastName.Length < 3)
        {
            throw new Exception();
        }

        LastName = lastName;
    }

    public void SetEmail(string email)
    {
        if (email.Length < 3)
        {
            throw new Exception();
        }

        if (!email.Contains("@"))
        {
            throw new Exception();
        }

        Email = email;
    }
}
