
using FluentValidation;
using static FluentWebApplication1.Classes.Extensions;

namespace FluentWebApplication1.Validators;

/// <summary>
/// Provides extension methods for adding custom validation rules to properties
/// using the FluentValidation library.
/// </summary>
public static class RuleBuilderExtensions
{
    /// <summary>
    /// Adds a validation rule to ensure that a nullable <see cref="DateOnly"/> property is not null 
    /// and falls within a valid date range.
    /// </summary>
    /// <typeparam name="T">The type of the object being validated.</typeparam>
    /// <param name="ruleBuilder">The rule builder for the property being validated.</param>
    /// <returns>
    /// An <see cref="IRuleBuilderOptions{T, TProperty}"/> that can be used to chain additional validation rules.
    /// </returns>
    /// <remarks>
    /// The valid date range is defined as being after 120 years ago and on or before today's date.
    /// If the property is null, only the "not null" validation rule will be triggered.
    /// </remarks>
    public static IRuleBuilderOptions<T, DateOnly?> DateRangeNotNullRule<T>(this IRuleBuilder<T, DateOnly?> ruleBuilder)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var minDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-120));

        return ruleBuilder
            .NotNull().WithMessage("'{PropertyName}' is required.")
            // Only run range check when there's a value to avoid duplicate errors
            .Must(x => x == null || (x.Value > minDate && x.Value <= today))
            .WithMessage($"'{{PropertyName}}' must be after {minDate} and on or before {today}.");
    }

    /// <summary>
    /// FluentValidation extension for validating a Social Security Number.
    /// </summary>
    /// <typeparam name="T">The type of the model being validated.</typeparam>
    /// <param name="ruleBuilder">The rule builder for the property.</param>
    /// <returns>
    /// An <see cref="IRuleBuilderOptions{T, string}"/> with SSN validation applied.
    /// </returns>
    public static IRuleBuilderOptions<T, string> SocialSecurityNumberRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(IsValidSocialSecurityNumber)
            .WithMessage("'{PropertyName}' must be a valid Social Security Number.");
    }
}


