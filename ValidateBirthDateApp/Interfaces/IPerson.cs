namespace ValidateBirthDateApp.Interfaces;

/// <summary>
/// Represents an individual with personal details such as first name, last name, and birthdate.
/// </summary>
public interface IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
