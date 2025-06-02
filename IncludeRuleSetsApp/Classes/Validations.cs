using FluentValidation;
using IncludeRuleSetsApp.Models;
using IncludeRuleSetsApp.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IncludeRuleSetsApp.Classes;

/// <summary>
/// Provides validation methods for the <see cref="Person"/> model using predefined rule sets.
/// </summary>
/// <remarks>
/// This static class contains extension methods that utilize the <see cref="PersonValidator"/> 
/// to validate <see cref="Person"/> instances. It supports validation against specific rule sets 
/// or all available rule sets defined in the <see cref="PersonValidator"/>.
/// </remarks>
public static class Validations
{
    /// <summary>
    /// Validates the current <see cref="Person"/> instance against the specified rule sets.
    /// </summary>
    /// <param name="person">
    /// The <see cref="Person"/> instance to validate.
    /// </param>
    /// <param name="rules">
    /// An array of rule set names to include during validation. These rule sets are defined 
    /// in the <see cref="PersonValidator"/>.
    /// </param>
    /// <returns>
    /// A <see cref="ValidationResult"/> containing the results of the validation.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when no rule set names are provided in the <paramref name="rules"/> parameter.
    /// </exception>
    /// <remarks>
    /// This extension method uses the <see cref="PersonValidator"/> to validate the 
    /// <see cref="Person"/> instance against the specified rule sets. The rule sets include 
    /// validations for properties such as names, identifiers, and birthdates.
    /// </remarks>
    public static ValidationResult SelectedRules(this Person person, params string[] rules)
    {
        if (rules == null || rules.Length == 0)
        {
            throw new ArgumentException("At least one rule set name must be provided.", nameof(rules));
        }

        var validator = new PersonValidator();


        return validator.Validate(person, options => options.IncludeRuleSets(rules));
    }

    /// <summary>
    /// Validates the specified <see cref="Person"/> instance against all defined rule sets.
    /// </summary>
    /// <param name="person">The <see cref="Person"/> instance to validate.</param>
    /// <returns>
    /// A <see cref="ValidationResult"/> containing the results of the validation process.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="PersonValidator"/> to validate the <see cref="Person"/> instance
    /// against all available rule sets by including the wildcard rule set pattern "*".
    /// </remarks>
    public static ValidationResult AllRules(this Person person)
    {
        var validator = new PersonValidator();
        return validator.Validate(person, options => options.IncludeRuleSets("*"));
    }

    /// <summary>
    /// Determines whether the specified <see cref="ValidationResult"/> indicates a successful validation.
    /// </summary>
    /// <param name="result">
    /// The <see cref="ValidationResult"/> to evaluate.
    /// </param>
    /// <returns>
    /// <c>true</c> if the validation result is successful; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method provides a convenient way to check the validity of a <see cref="ValidationResult"/> 
    /// returned by the <see cref="PersonValidator"/>.
    /// </remarks>
    public static bool IsValid(this ValidationResult result) => result.IsValid;

    /// <summary>
    /// Prints the validation errors from the specified <see cref="ValidationResult"/>.
    /// </summary>
    /// <param name="result">
    /// The <see cref="ValidationResult"/> containing the validation errors to print.
    /// </param>
    /// <remarks>
    /// If the <paramref name="result"/> is valid, this method does nothing. Otherwise, it iterates 
    /// through the <see cref="ValidationResult.Errors"/> collection and prints each error's 
    /// property name and error message.
    /// </remarks>
    public static void PrintErrors(this ValidationResult result)
    {
        if (result.IsValid) return;
        foreach (var error in result.Errors)
        {
            AnsiConsole.MarkupLine($"{error.PropertyName,-14} [red]Error:[/] {error.ErrorMessage}");
        }
    }
}
