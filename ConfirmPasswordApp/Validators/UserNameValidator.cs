using ConfirmPasswordApp.Interfaces;
using FluentValidation;

namespace ConfirmPasswordApp.Validators;

/// <summary>
/// Provides validation rules for the <see cref="IUser.UserName"/> property of an object implementing <see cref="IUser"/>.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="IUser.UserName"/> property is not empty and meets the minimum length requirement of 3 characters.
/// </remarks>
public class UserNameValidator : AbstractValidator<IUser>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserNameValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines validation rules for the <see cref="IUser.UserName"/> property.
    /// It ensures that the property is not empty and has a minimum length of 3 characters.
    /// </remarks>
    public UserNameValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);
    }
}