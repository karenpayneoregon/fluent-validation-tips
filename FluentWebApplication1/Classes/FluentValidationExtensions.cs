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
    /// Validates the specified <paramref name="instance"/> using the provided <paramref name="validator"/>.
    /// If the validation fails, the <paramref name="onError"/> action is invoked for each <see cref="ValidationFailure"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object being validated.</typeparam>
    /// <param name="validator">
    /// The <see cref="IValidator{T}"/> instance used to validate the <paramref name="instance"/>. 
    /// Cannot be <see langword="null"/>.
    /// </param>
    /// <param name="instance">
    /// The object to validate. Cannot be <see langword="null"/>.
    /// </param>
    /// <param name="onError">
    /// An action to execute for each <see cref="ValidationFailure"/> if validation fails. 
    /// Cannot be <see langword="null"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="instance"/> is valid; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="validator"/> or <paramref name="onError"/> is <see langword="null"/>.
    /// </exception>
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
    /// Iterates over the validation failures in the specified <see cref="ValidationResult"/> 
    /// and invokes the provided <paramref name="onError"/> action for each failure. 
    /// If the <see cref="ValidationResult"/> is valid, no action is performed.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> to process. Cannot be <see langword="null"/>.</param>
    /// <param name="onError">
    /// An action to execute for each <see cref="ValidationFailure"/> in the <see cref="ValidationResult"/>. 
    /// Cannot be <see langword="null"/>.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="result"/> or <paramref name="onError"/> is <see langword="null"/>.
    /// </exception>
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
    /// Throws a <see cref="ValidationException"/> if the <see cref="ValidationResult"/> is invalid, 
    /// including a detailed and readable message summarizing the validation errors.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> to evaluate. Cannot be <see langword="null"/>.</param>
    /// <param name="prefix">
    /// An optional prefix to include in the exception message. If <see langword="null"/> or whitespace, 
    /// "Validation failed" will be used as the default header.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="result"/> is <see langword="null"/>.</exception>
    /// <exception cref="ValidationException">
    /// Thrown if the <see cref="ValidationResult"/> is invalid, containing a message summarizing all validation errors.
    /// </exception>
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
    /// Converts the validation failures in the <see cref="ValidationResult"/> into a dictionary
    /// where the key is the property name and the value is a list of error messages associated with that property.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> containing validation failures. Cannot be <see langword="null"/>.</param>
    /// <returns>A dictionary where each key is a property name and the value is a list of error messages for that property.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="result"/> is <see langword="null"/>.</exception>
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
    /// Converts the validation failures in the <see cref="ValidationResult"/> into a list of formatted error messages.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> containing validation failures. Cannot be <see langword="null"/>.</param>
    /// <returns>A list of strings where each entry is formatted as "PropertyName: Message".</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="result"/> is <see langword="null"/>.</exception>
    public static List<string> ToErrorList(this ValidationResult result)
    {
        return result is null
            ? throw new ArgumentNullException(nameof(result))
            : result.Errors
                .Select(f => $"{f.PropertyName}: {f.ErrorMessage}")
                .ToList();
    }

    /// <summary>
    /// Formats the specified value as a string representation suitable for display.
    /// </summary>
    /// <param name="value">The value to format. Can be <see langword="null"/>.</param>
    /// <returns>A string representation of the value. Returns "null" if <paramref name="value"/> is <see langword="null"/>, 
    /// "(empty)" if the value is a whitespace-only string, or the result of <see cref="object.ToString"/>  if the value
    /// is non-null. If <see cref="object.ToString"/> returns <see langword="null"/>, "(unprintable)" is returned.</returns>
    private static string FormatValue(object? value) =>
        value switch
        {
            null => "null",
            string s => string.IsNullOrWhiteSpace(s) ? "(empty)" : s,
            _ => value.ToString() ?? "(unprintable)"
        };
}

