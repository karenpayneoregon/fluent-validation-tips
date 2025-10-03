namespace WebValidationLibrary1.Interfaces;

/// <summary>
/// Represents the birthdate information.
/// </summary>
public interface IBirthDate
{
    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    /// <value>
    /// The date of birth as a <see cref="DateOnly"/>. 
    /// It can be <c>null</c> if the date of birth is not specified.
    /// </value>
    DateOnly? DateOfBirth { get; set; }
}