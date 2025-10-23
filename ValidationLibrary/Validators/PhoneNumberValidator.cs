using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Person.PhoneNumber"/> property.
/// Ensures that the phone number is not empty and matches the expected format.
/// </summary>
public class PhoneNumberValidator : AbstractValidator<Person>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneNumberValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines validation rules for the <see cref="Person.PhoneNumber"/> property.
    /// It ensures that the phone number is not empty and matches the expected format.
    /// </remarks>
    public PhoneNumberValidator()
    {
        RuleFor(person => person.PhoneNumber)
            .NotEmpty()
            .MatchPhoneNumber();
    }
}

/// <summary>
/// Provides extension methods for adding phone number validation rules to FluentValidation validators.
/// </summary>
public static class PhoneNumberValidationExtensions
{
    public static IRuleBuilderOptions<T, string> MatchPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.Matches(@"^\d{3}-?\d{3}-?\d{4}$")
            .WithMessage("Invalid phone number format. Expected format: 111-111-1111 or 1111111111");
}

