namespace PersonelTakip.Domain.Models;
public sealed class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateOnly StartDate { get; set; }
    public decimal Salary { get; set; }
    public string IdentityNumber { get; set; } = default!;
    public bool IsDeleted { get; set; }
}
