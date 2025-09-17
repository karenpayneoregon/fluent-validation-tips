using ValidationLibrary1.Models;

namespace ValidationLibrary1.Interfaces;

public interface IPerson
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    Gender Gender { get; set; }
    DateTime DateOfBirth { get; set; }
}