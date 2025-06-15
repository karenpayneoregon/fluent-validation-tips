#nullable disable

using IncludeRuleSetsApp.Interfaces;

namespace IncludeRuleSetsApp.Models;

public class Person : IPerson
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public DateOnly BirthDate { get; set; }
}