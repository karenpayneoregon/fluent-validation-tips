﻿using System.Text.Json;

namespace InlineValidationSample.Classes;

/// <summary>
/// Utility class that provides helper methods and properties for performing inline validation.
/// 
/// Overall, the ValidationHelpers class serves as a central location for accessing validation-related data
/// stored in a JSON file Validation.json, making it easier to perform inline validation in the application.
/// 
/// </summary>
internal static class ValidationHelpers
{
    private static ValidationContainer _container =>
        JsonSerializer.Deserialize<ValidationContainer>(File.ReadAllText("Validation.json"));

    /// <summary>
    /// Person titles
    /// </summary>
    public static string[] Titles => [.. _container.Titles];

    /// <summary>
    /// Contact types e.g. owner, manager, etc.
    /// </summary>
    public static string[] ContactTypes = [.. _container.ContactTypes];

    /// <summary>
    /// <see cref="Developer"/> types
    /// </summary>
    public static string[] DeveloperTypes = [.. _container.DeveloperTypes];

}
