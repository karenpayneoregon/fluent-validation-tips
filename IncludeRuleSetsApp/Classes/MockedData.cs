using IncludeRuleSetsApp.Models;

namespace IncludeRuleSetsApp.Classes;

/// <summary>
/// Provides a collection of predefined <see cref="Person"/> objects for testing and validation purposes.
/// </summary>
/// <remarks>
/// This class includes static properties representing various test cases:
/// <list type="bullet">
/// <item>
/// <description><see cref="ValidPerson"/>: A valid <see cref="Person"/> object with all required properties populated.</description>
/// </item>
/// <item>
/// <description><see cref="MissingIdPerson"/>: A <see cref="Person"/> object with a missing or invalid <see cref="Person.PersonId"/>.</description>
/// </item>
/// <item>
/// <description><see cref="MissingNamesPerson"/>: A <see cref="Person"/> object with missing <see cref="Person.FirstName"/> and <see cref="Person.LastName"/>.</description>
/// </item>
/// <item>
/// <description><see cref="InvalidPerson"/>: A completely invalid <see cref="Person"/> object with null or default values for all properties.</description>
/// </item>
/// </list>
/// </remarks>
internal class MockedData
{
    public static Person ValidPerson => new Person
    {
        FirstName = "John",
        LastName = "Doe",
        PersonId = 1,
        EmailAddress = "doe@gmail.com",
        BirthDate = new DateOnly(2000,1,12)
    };

    public static Person MissingIdPerson => new Person
    {
        FirstName = "John",
        LastName = "Doe",
        PersonId = 0
    };

    public static Person MissingNamesPerson => new Person
    {
        PersonId = 10
    };

    public static Person InvalidPerson => new Person
    {
        FirstName = null,
        LastName = null,
        PersonId = 0
    };
}
