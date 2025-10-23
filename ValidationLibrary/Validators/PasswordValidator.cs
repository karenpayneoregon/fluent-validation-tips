using FluentValidation;
using ValidationLibrary.Models;
// ReSharper disable RedundantVerbatimStringPrefix

namespace ValidationLibrary.Validators;

/// <summary>
/// Provides validation logic for the <see cref="Person.Password"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the password meets complexity requirements and matches the confirmation password.
/// It includes the following rules:
/// <list type="bullet">
/// <item><description>Applies complexity checks using <see cref="PasswordComplexityValidator"/>.</description></item>
/// <item><description>Ensures the password matches the <see cref="Person.PasswordConfirmation"/> property.</description></item>
/// </list>
/// </remarks>
public class PasswordValidator : AbstractValidator<Person>
{
    public PasswordValidator()
    {
        // Run complexity checks first, then match check.
        ClassLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(p => p.Password).SetValidator(new PasswordComplexityValidator());

        RuleFor(p => p.Password)
            .Equal(p => p.PasswordConfirmation)
            .WithState(_ => StatusCodes.PasswordsMisMatch)
            .WithMessage("Password and confirmation must match.");
    }
}

