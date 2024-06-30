using ValidateBirthDateApp.Interfaces;

namespace ValidateBirthDateApp.Models;

public class Person : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
