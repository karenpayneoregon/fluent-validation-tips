namespace WebValidationLibrary1.Interfaces;

/// <summary>
/// Represents an individual's name.
/// </summary>
public interface INames
{
    /// <summary>
    /// Gets or sets the first name of the individual.
    /// </summary>
    string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the middle name of the individual.
    /// </summary>
    string MiddleName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the individual.
    /// </summary>
    string LastName { get; set; }
}