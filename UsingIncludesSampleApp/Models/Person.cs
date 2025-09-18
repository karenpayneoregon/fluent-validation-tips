using ValidationLibrary1.Interfaces;
using ValidationLibrary1.Models;

namespace UsingIncludesSampleApp.Models;
public class Person : IPerson
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Gender Gender { get; set; }
    public required DateTime DateOfBirth { get; set; }
}