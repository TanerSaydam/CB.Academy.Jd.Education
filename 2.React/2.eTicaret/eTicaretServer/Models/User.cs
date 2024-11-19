namespace eTicaretServer.Models;

public sealed class User
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}
