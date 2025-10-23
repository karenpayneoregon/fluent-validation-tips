using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

/// <summary>
/// Provides validation logic for the <see cref="ValidationLibrary.Models.Person.UserName"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the username is not empty and meets the minimum length requirement.
/// </remarks>
public class UserNameValidator : AbstractValidator<Person>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserNameValidator"/> class.
    /// </summary>
    public UserNameValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);
    }
}

