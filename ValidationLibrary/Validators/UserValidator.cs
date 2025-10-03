using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

/// <summary>
/// Provides validation logic for the <see cref="ValidationLibrary.Models.Person"/> class.
/// </summary>
/// <remarks>
/// This validator includes rules for validating user-related properties such as:
/// <list type="bullet">
/// <item><description>Username validation through <see cref="Validators.UserNameValidator"/>.</description></item>
/// <item><description>Email address validation through <see cref="Validators.EmailAddressValidator"/>.</description></item>
/// <item><description>Password validation through <see cref="Validators.PasswordValidator"/>.</description></item>
/// </list>
/// </remarks>
public class UserValidator : AbstractValidator<Person>
{
    public UserValidator()
    {
        Include(new UserNameValidator());
        Include(new EmailAddressValidator());
        Include(new PasswordValidator());
    }
}


