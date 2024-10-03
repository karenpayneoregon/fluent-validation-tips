using InheritanceValidationApp.Interfaces;

namespace InheritanceValidationApp.Models;

public class Person : IContact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}