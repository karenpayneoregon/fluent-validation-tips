using ValidationLibrary1.Interfaces;

namespace ValidationLibrary1.Models;

public class Customer : IPerson
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Gender Gender { get; set; }
    public required DateTime DateOfBirth { get; set; }
}