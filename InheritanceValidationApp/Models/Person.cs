using InheritanceValidationApp.Interfaces;

namespace InheritanceValidationApp.Models;
/// <summary>
/// Represents a person with contact information and date of birth.
/// Implements the <see cref="IContact"/> interface.
/// </summary>
public class Person : IContact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}