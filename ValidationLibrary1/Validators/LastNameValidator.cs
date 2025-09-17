using FluentValidation;
using ValidationLibrary1.Interfaces;

namespace ValidationLibrary1.Validators;

/// <summary>
/// Provides validation rules for the <see cref="IPerson.LastName"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="IPerson.LastName"/> is not empty and has a minimum length of 3 characters.
/// </remarks>
public class LastNameValidator : AbstractValidator<IPerson>
{
    public LastNameValidator()
    {

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(3);

    }
}