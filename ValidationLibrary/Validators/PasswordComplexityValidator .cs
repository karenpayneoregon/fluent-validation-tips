using FluentValidation;

namespace ValidationLibrary.Validators;


/// <summary>
/// Provides validation logic to enforce password complexity requirements.
/// </summary>
/// <remarks>
/// This validator ensures that a password adheres to the following complexity rules:
/// <list type="bullet">
/// <item><description>The password cannot be empty.</description></item>
/// <item><description>The password must be at least 8 characters long.</description></item>
/// <item><description>The password must not exceed 16 characters in length.</description></item>
/// <item><description>The password must contain at least one uppercase letter.</description></item>
/// <item><description>The password must contain at least one lowercase letter.</description></item>
/// <item><description>The password must contain at least one numeric digit.</description></item>
/// <item><description>The password can only include letters, numbers, and the following special characters: <c>! ? * . @</c>.</description></item>
/// </list>
/// </remarks>
public class PasswordComplexityValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PasswordComplexityValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator enforces the following password complexity rules:
    /// <list type="bullet">
    /// <item><description>The password cannot be empty.</description></item>
    /// <item><description>The password must be at least 8 characters long.</description></item>
    /// <item><description>The password must not exceed 16 characters in length.</description></item>
    /// <item><description>The password must contain at least one uppercase letter.</description></item>
    /// <item><description>The password must contain at least one lowercase letter.</description></item>
    /// <item><description>The password must contain at least one numeric digit.</description></item>
    /// <item><description>The password can only include letters, numbers, and the following special characters: <c>! ? * . @</c>.</description></item>
    /// </list>
    /// </remarks>
    public PasswordComplexityValidator()
    {
        RuleFor(pwd => pwd)
            .NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
            .Matches(@"^[A-Za-z0-9!?\*@\.]+$").WithMessage("Your password contains invalid characters. Allowed: letters, numbers, and ! ? * . @");
    }
}



