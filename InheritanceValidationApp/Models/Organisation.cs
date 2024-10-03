using InheritanceValidationApp.Interfaces;

namespace InheritanceValidationApp.Models;
/// <summary>
/// Represents an organization with contact information and headquarters address.
/// </summary>
public class Organisation : IContact
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Address Headquarters { get; set; }
}