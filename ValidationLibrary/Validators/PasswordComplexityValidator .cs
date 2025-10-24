using FluentValidation;
using System.Text.RegularExpressions;

namespace ValidationLibrary.Validators;


/// <summary>
/// Provides validation logic to enforce password complexity requirements.
/// </summary>
public partial class PasswordComplexityValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PasswordComplexityValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor sets up the validation rules to ensure that passwords meet the defined complexity requirements:
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
            .Must(HasUpperCase).WithMessage("Your password must contain at least one uppercase letter.")
            .Must(HasLowerCase).WithMessage("Your password must contain at least one lowercase letter.")
            .Must(HasDigit).WithMessage("Your password must contain at least one number.")
            .Must(IsValidCharacterSet).WithMessage("Your password contains invalid characters. Allowed: letters, numbers, and ! ? * . @");
    }

    private static bool HasUpperCase(string pwd) => UpperCaseRegex().IsMatch(pwd);
    private static bool HasLowerCase(string pwd) => LowerCaseRegex().IsMatch(pwd);
    private static bool HasDigit(string pwd) => DigitRegex().IsMatch(pwd);
    private static bool IsValidCharacterSet(string pwd) => AllowedCharsRegex().IsMatch(pwd);

    [GeneratedRegex("[A-Z]+")]
    private static partial Regex UpperCaseRegex();

    [GeneratedRegex("[a-z]+")]
    private static partial Regex LowerCaseRegex();

    [GeneratedRegex("[0-9]+")]
    private static partial Regex DigitRegex();

    [GeneratedRegex("^[A-Za-z0-9!\\?\\*@\\.]+$")]
    private static partial Regex AllowedCharsRegex();
}
