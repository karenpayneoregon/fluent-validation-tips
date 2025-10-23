using System.Text.Json;
using FluentValidation.Results;

namespace WebValidationLibrary1.LanguageExtensions;

/// <summary>
/// Provides extension methods for FluentValidation to simplify validation and error handling.
/// </summary>
public static class FluentValidationExtensions
{

    /// <summary>
    /// Converts the validation failures in the <see cref="ValidationResult"/> into a dictionary
    /// where the key is the property name and the value is a list of error messages associated with that property.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> containing validation failures. Cannot be <see langword="null"/>.</param>
    /// <returns>A dictionary where each key is a property name and the value is a list of error messages for that property.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="result"/> is <see langword="null"/>.</exception>
    public static IDictionary<string, List<string>> ToErrorDictionary(this ValidationResult result) =>
        result is null
            ? throw new ArgumentNullException(nameof(result))
            : result.Errors
                .GroupBy(f => f.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(f => f.ErrorMessage).ToList());

    private static JsonSerializerOptions JsonSerializerOptions => new() { WriteIndented = true };  
    
    /// <summary>
    /// Converts the validation failures in the <see cref="ValidationResult"/> into a JSON string.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> containing validation failures. Cannot be <see langword="null"/>.</param>
    /// <returns>A JSON string representing the validation failures, where each property name is associated with its list of error messages.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="result"/> is <see langword="null"/>.</exception>
    public static string ToJson(this ValidationResult result) =>
        result is null
            ? "{}"
            : JsonSerializer.Serialize(result.ToErrorDictionary(), JsonSerializerOptions);

}

