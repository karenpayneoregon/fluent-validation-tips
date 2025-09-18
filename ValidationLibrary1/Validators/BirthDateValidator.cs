using FluentValidation;
using ValidationLibrary1.Interfaces;

namespace ValidationLibrary1.Validators;

/// <summary>
/// Provides validation rules for the <see cref="ValidationLibrary1.Interfaces.IPerson.DateOfBirth"/> property.
/// </summary>
/// <remarks>
/// Ensures that the date of birth is within the valid range of January 1, 1910, to the current date.
/// The minimum date is set to January 1, 1910, and the maximum date could be read from a
/// configuration file in a real-world application.
/// </remarks>
public class BirthDateValidator : AbstractValidator<IPerson>
{
    public BirthDateValidator()
    {
        RuleFor(p => p.DateOfBirth)
            .InclusiveBetween(new DateTime(1910, 1, 1), DateTime.Today)
            .WithMessage("Birthdate must be between 01/01/1910 and today.")
            .WithName("BirthDate");
    }
}
