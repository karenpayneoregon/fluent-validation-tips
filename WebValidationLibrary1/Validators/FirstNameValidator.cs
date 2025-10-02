using FluentValidation;
using WebValidationLibrary1.Interfaces;

namespace WebValidationLibrary1.Validators;

/// <summary>
/// Provides validation rules for the <see cref="INames.FirstName"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="INames.FirstName"/> property is not empty,
/// has a maximum length of 100 characters, and stops further validation upon the first failure.
/// </remarks>
public class FirstNameValidator : AbstractValidator<INames>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FirstNameValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines validation rules for the <see cref="INames.FirstName"/> property:
    /// <list type="bullet">
    /// <item>
    /// Ensures the property is not empty, returning an error message if it is.
    /// </item>
    /// <item>
    /// Restricts the maximum length of the property to 100 characters.
    /// </item>
    /// <item>
    /// Stops further validation upon the first failure.
    /// </item>
    /// </list>
    /// </remarks>
    public FirstNameValidator()
    {

        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("First Name is required...")
            .MaximumLength(100)
            .WithMessage("First Name is required...");

    }
}