using FluentValidation;
using ValidationLibrary1.Interfaces;

namespace ValidationLibrary1.Validators;

/// <summary>
/// Provides validation rules for the <see cref="ValidationLibrary1.Interfaces.IPerson.FirstName"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="ValidationLibrary1.Interfaces.IPerson.FirstName"/> property
/// is not empty and has a minimum length of 3 characters.
/// </remarks>
public class FirstNameValidator : AbstractValidator<IPerson>
{
    public FirstNameValidator()
    {

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(3);

    }
}