namespace ValidateBirthDateApp.Interfaces;

/// <summary>
/// For validation rules for first and last name
/// </summary>
public interface IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
