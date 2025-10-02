using FluentValidation;
using WebValidationLibrary1.Interfaces;

namespace WebValidationLibrary1.Validators;


/// <summary>
/// Provides validation rules for the <see cref="INames.LastName"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="INames.LastName"/> property is not empty,
/// has a maximum length of 100 characters, and uses a custom display name "Last name".
/// </remarks>
public class LastNameValidator : AbstractValidator<INames>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LastNameValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines validation rules for the <see cref="INames.LastName"/> property:
    /// <list type="bullet">
    /// <item><description>Ensures the property is not empty.</description></item>
    /// <item><description>Restricts the maximum length to 100 characters.</description></item>
    /// <item><description>Uses a custom display name "Last name" for error messages.</description></item>
    /// </list>
    /// </remarks>
    public LastNameValidator()
    {

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required...")
            .MaximumLength(100)
            .WithName("Last name");

    }
}