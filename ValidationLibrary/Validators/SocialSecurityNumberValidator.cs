using FluentValidation;

namespace ValidationLibrary.Validators;
public class SocialSecurityNumberValidator : AbstractValidator<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SocialSecurityNumberValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the provided Social Security Number (SSN) is not empty
    /// and adheres to a valid SSN format using the <see cref="SpecialValidation.IsValidSocialSecurityNumber"/> method.
    /// </remarks>
    public SocialSecurityNumberValidator()
    {
        var specialValidation = new SpecialValidation();
        RuleFor(x => x)
            .NotEmpty().WithMessage("Social Security Number is required.")
            .Must(specialValidation.IsValidSocialSecurityNumber)
            .WithMessage("Invalid Social Security Number format.");
    }
}