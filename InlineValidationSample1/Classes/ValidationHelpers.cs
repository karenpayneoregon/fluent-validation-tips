using System.Text.Json;
using InlineValidationSample1.Models;
#nullable disable
namespace InlineValidationSample1.Classes;

/// <summary>
/// Utility class that provides helper methods and properties for performing inline validation.
/// 
/// Overall, the ValidationHelpers class serves as a central location for accessing validation-related data
/// stored in a JSON file Validation.json, making it easier to perform inline validation in the application.
/// 
/// </summary>
internal static class ValidationHelpers
{
    private static ValidationContainer? _container =>
        JsonSerializer.Deserialize<ValidationContainer>(File.ReadAllText("Validation.json"));

    /// <summary>
    /// Person titles
    /// </summary>
    public static string[] Titles => [.. _container!.Titles];
    /// <summary>
    /// Gender options (NotSet is for demonstration purposes)
    /// </summary>
    public static string[] Genders => [.. _container!.Genders];

    /// <summary>
    /// Valid Gender options
    /// </summary>
    public static Gender[] GenderTypes
        => Genders
            .Where(x => x != "NotSet")
            .Select(a => (Gender)Enum.Parse(typeof(Gender), a))
            .ToArray();

    public static int MinYear => _container.Settings.MinYear;
}
