using FluentValidation;
using ValidationLibrary1.Interfaces;

namespace ValidationLibrary1.Validators;

/// <summary>
/// Serves as a base validator for validating <see cref="ValidationLibrary1.Interfaces.IPerson"/> entities.
/// </summary>
/// <remarks>
/// This validator combines multiple specific validators, including:
/// <list type="bullet">
/// <item><see cref="FirstNameValidator"/> for validating the <see cref="IPerson.FirstName"/> property.</item>
/// <item><see cref="LastNameValidator"/> for validating the <see cref="IPerson.LastName"/> property.</item>
/// <item><see cref="BirthDateValidator"/> for validating the <see cref="IPerson.DateOfBirth"/> property.</item>
/// </list>
/// </remarks>
public class BasePersonValidator : AbstractValidator<IPerson>
{
    public BasePersonValidator()
    {
        Include(new FirstNameValidator());
        Include(new LastNameValidator());
        Include(new BirthDateValidator());
    }
}
