using FluentValidation;

namespace ValidationLibrary.Validators;
public class SocialSecurityNumberValidator : AbstractValidator<string>
{
    public SocialSecurityNumberValidator()
    {
        var specialValidation = new SpecialValidation();
        RuleFor(x => x)
            .NotEmpty().WithMessage("Social Security Number is required.")
            .Must(specialValidation.IsValidSocialSecurityNumber)
            .WithMessage("Invalid Social Security Number format.");
    }
}