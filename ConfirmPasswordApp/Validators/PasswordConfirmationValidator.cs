using ConfirmPasswordApp.Interfaces;
using FluentValidation;

namespace ConfirmPasswordApp.Validators;

/// <summary>
/// Validates that the password and confirmation password fields of an object implementing <see cref="IPassword"/> match.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="IPassword.Password"/> and <see cref="IPassword.ConfirmPassword"/> properties
/// are equal, providing a mechanism to enforce consistency between the two fields.
/// </remarks>
public class PasswordConfirmationValidator : AbstractValidator<IUser>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="PasswordConfirmationValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines a validation rule that ensures the <see cref="IPassword.Password"/> 
    /// and <see cref="IPassword.ConfirmPassword"/> properties of an <see cref="IUser"/> object are equal.
    /// If the properties do not match, a validation error with the message "Passwords do not match" is generated.
    /// </remarks>
    public PasswordConfirmationValidator()
    {
        RuleFor(user => user.Password)
            .Equal(customer => customer.ConfirmPassword).WithMessage("Passwords do not match");
    }
}