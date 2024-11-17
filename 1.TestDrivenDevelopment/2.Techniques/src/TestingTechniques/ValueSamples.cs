namespace TestingTechniques;

public class ValueSamples
{
    public string FullName = "Taner Saydam";

    public int Age = 35;

    public DateOnly DateOfBirth = new(1989, 09, 03);

    public User AppUser = new()
    {
        FullName = "Taner Saydam",
        Age = 35,
        DateOfBirth = new(1989, 09, 03)
    };

    public IEnumerable<User> Users = new[]
    {
        new User()
        {
            FullName = "Taner Saydam",
            Age = 35,
            DateOfBirth = new(1989, 09, 03)
        },
        new User()
        {
            FullName = "Toprak Saydam",
            Age = 5,
            DateOfBirth = new(2019, 09, 07)
        }
    };

    public List<int> Numbers = new() { 1, 2, 3, 4, 5 };

    private int Stock = 10;
    internal decimal Salary = 150000;
}

public class User
{
    //public string FirstName { get; set; } = default!;
    //public string LastName { get; set; } = default!;
    //public string FullName => string.Join(" ", FirstName, LastName);

    public string FullName { get; set; } = default!;
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
}


public class User2
{
    public string FullName { get; set; } = default!;
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
}