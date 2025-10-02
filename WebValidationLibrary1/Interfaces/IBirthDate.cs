namespace WebValidationLibrary1.Interfaces;

/// <summary>
/// Represents the birthdate information.
/// </summary>
public interface IBirthDate
{
    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    DateOnly? DateOfBirth { get; set; }
}