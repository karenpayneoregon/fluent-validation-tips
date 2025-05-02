using ConfirmPasswordApp.Interfaces;
using FluentValidation;

namespace ConfirmPasswordApp.Validators;

/// <summary>
/// Provides validation rules for user passwords, ensuring compliance with specific security requirements.
/// </summary>
/// <remarks>
/// This validator enforces rules such as minimum and maximum password length, 
/// the inclusion of uppercase and lowercase letters, numbers, and special characters. 
/// It also ensures that the password and confirmation password fields match.
///
/// For some companies the rules are not to be shown, instead point to a web page for current rules.
/// </remarks>
public class UserValidator : AbstractValidator<IUser>
{
    public UserValidator()
    {
        
        Include(new PasswordConfirmationValidator());
        Include(new UserNameValidator());

        RuleFor(p => p.Password)
            .NotEmpty()
            .WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(24).WithMessage("Your password length must not exceed 24.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty();
    }
}