using UsingIncludeInValidationLibrary.Models;

namespace UsingIncludeInValidationLibrary.Interfaces;

public interface IPerson : IFormattable
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
    Address Address { get; set; }
}