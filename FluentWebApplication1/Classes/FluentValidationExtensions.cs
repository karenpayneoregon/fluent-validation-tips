using FluentValidation;
using FluentValidation.Results;

namespace FluentWebApplication1.Classes;

/// <summary>
/// FluentValidation helpers to keep validation+error handling terse and consistent.
/// </summary>
/// <summary>
/// FluentValidation helpers to keep validation+error handling terse and consistent.
/// </summary>
public static class FluentValidationExtensions
{
    /// <summary>
    /// Validates the instance and, if invalid, invokes <paramref name="onError"/> for each failure.
    /// Returns true when valid; false when invalid.
    /// </summary>
    public static bool ValidateAndForEachError<T>(this IValidator<T> validator, T instance, Action<ValidationFailure> onError)
    {
        if (validator is null) throw new ArgumentNullException(nameof(validator));
        if (onError is null) throw new ArgumentNullException(nameof(onError));

        var result = validator.Validate(instance);
        
        if (!result.IsValid)
        {
            foreach (var failure in result.Errors)
            {
                onError(failure);
            }

            return false;
        }

        return true;
    }

    /// <summary>
    /// Iterates failures on a ValidationResult. No-ops if valid.
    /// </summary>
    public static void ForEachError(this ValidationResult result, Action<ValidationFailure> onError)
    {
        if (result is null) throw new ArgumentNullException(nameof(result));
        if (onError is null) throw new ArgumentNullException(nameof(onError));

        if (!result.IsValid)
        {
            foreach (var failure in result.Errors)
            {
                onError(failure);
            }
        }
        
    }

    /// <summary>
    /// Throws ValidationException if invalid, with a compact, readable message.
    /// </summary>
    public static void ThrowIfInvalid(this ValidationResult result, string? prefix = null)
    {
        if (result is null) throw new ArgumentNullException(nameof(result));

        if (result.IsValid) return;
        
        var header = string.IsNullOrWhiteSpace(prefix) ? "Validation failed" : prefix.Trim();
        var message = $"{header}:{Environment.NewLine}{string.Join(Environment.NewLine, result.Errors.Select(f =>
            $"- {f.PropertyName}: {f.ErrorMessage} (AttemptedValue: {FormatValue(f.AttemptedValue)})"))}";
            
        throw new ValidationException(message, result.Errors);
    }

    /// <summary>
    /// Converts failures to a dictionary: PropertyName -> list of messages.
    /// </summary>
    public static IDictionary<string, List<string>> ToErrorDictionary(this ValidationResult result)
    {
        return result is null
            ? throw new ArgumentNullException(nameof(result))
            : result.Errors
                .GroupBy(f => f.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(f => f.ErrorMessage).ToList());
    }

    /// <summary>
    /// Flattens failures into a list of "PropertyName: Message".
    /// </summary>
    public static List<string> ToErrorList(this ValidationResult result)
    {
        return result is null
            ? throw new ArgumentNullException(nameof(result))
            : result.Errors
                .Select(f => $"{f.PropertyName}: {f.ErrorMessage}")
                .ToList();
    }


    private static string FormatValue(object? value) =>
        value switch
        {
            null => "null",
            string s => string.IsNullOrWhiteSpace(s) ? "(empty)" : s,
            _ => value.ToString() ?? "(unprintable)"
        };
}

