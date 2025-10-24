using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

/// <summary>
/// Provides validation logic for the <see cref="Person.EmailAddress"/> property.
/// </summary>
/// <remarks>
/// This validator ensures that the email address is not empty and adheres to a valid email format.
/// It uses a combination of rules, including:
/// <list type="bullet">
/// <item><description>Checking for non-empty values.</description></item>
/// <item><description>Validating the format of the email address.</description></item>
/// </list>
/// </remarks>
public partial class EmailAddressValidator : AbstractValidator<Person>
{
    public EmailAddressValidator()
    {
        RuleFor(person => person.EmailAddress)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email address is required.")
            .Must(IsValidEmail)
            .WithMessage("Email address is not in a valid format.");
    }

    private static bool IsValidEmail(string email) 
        => !string.IsNullOrWhiteSpace(email) && EmailAddressRegex().IsMatch(email.Trim());

    [GeneratedRegex("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex EmailAddressRegex();
}
