using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

/// <summary>
/// Provides validation rules for the <see cref="ValidationLibrary.Models.Person"/> class.
/// </summary>
/// <remarks>
/// This validator includes the following sub-validators:
/// <list type="bullet">
/// <item><see cref="PasswordValidator"/></item>
/// <item><see cref="EmailAddressValidator"/></item>
/// <item><see cref="PhoneNumberValidator"/></item>
/// <item><see cref="UserNameValidator"/></item>
/// </list>
/// </remarks>
public class PersonValidator : AbstractValidator<Person>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator combines multiple validation rules for a <see cref="Person"/> object, 
    /// including username, password, email address, and phone number validations.
    /// </remarks>
    public PersonValidator()
    {
        Include(new UserNameValidator());
        Include(new PasswordValidator());
        Include(new EmailAddressValidator());
        Include(new PhoneNumberValidator());
    }
}

