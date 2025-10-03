using FluentValidation;

namespace ValidateBirthDateApp.LanguageExtensions;

/// <summary>
/// Provides extension methods for FluentValidation's <see cref="IRuleBuilder{T, TProperty}"/> 
/// to define custom validation rules specific to the application.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Defines a validation rule for a birthdate, ensuring the year is within a valid range.
    /// </summary>
    /// <typeparam name="T">The type of the object being validated.</typeparam>
    /// <param name="ruleBuilder">
    /// The <see cref="IRuleBuilder{T, TProperty}"/> used to build the validation rule.
    /// </param>
    /// <returns>
    /// An <see cref="IRuleBuilderOptions{T, TProperty}"/> that represents the configured validation rule.
    /// </returns>
    /// <remarks>
    /// The birthdate year must be greater than the year calculated as 120 years before the current year
    /// and less than or equal to the current year.
    /// </remarks>
    public static IRuleBuilderOptions<T, DateOnly> BirthDateRule<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {

        int minYear = DateTime.Now.AddYears(-120).Year;

        return ruleBuilder
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage("'{PropertyName}'" +
                         $" must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }

}
