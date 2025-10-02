using WebValidationLibrary1.Models;

namespace WebValidationLibrary1.Interfaces;

/// <summary>
/// Defines a contract for objects that include a gender property.
/// </summary>
/// <remarks>
/// This interface is intended to be implemented by classes that need to represent or validate
/// gender-related information. It includes a <see cref="Gender"/> property for specifying
/// the gender of an individual.
/// </remarks>
public interface IGender
{
    /// <summary>
    /// Gets or sets the gender of an individual.
    /// </summary>
    /// <value>
    /// A nullable <see cref="Gender"/> value representing the gender of the individual.
    /// </value>
    /// <remarks>
    /// This property is used to specify or retrieve the gender of an individual. 
    /// Valid values include <see cref="Gender.Male"/>, <see cref="Gender.Female"/>, or <see cref="Gender.Unspecified"/>.
    /// </remarks>
    Gender? Gender { get; set; }
}