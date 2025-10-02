using FluentValidation;
using FluentWebApplication1.Models;
using WebValidationLibrary1.LanguageExtensions;

namespace FluentWebApplication1.Validators;

public sealed class CustomerValidator : AbstractValidator<Customer>
{

    public CustomerValidator()
    {

        RuleFor(x => x.DateOfBirth).DateRangeNotNullRule();


        RuleFor(x => x.SocialSecurityNumber)
            .NotEmpty().WithMessage("Social Security Number is required.")
            .SocialSecurityNumberRule();


        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("First Name is required...");


        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required...")
            .MaximumLength(100);

        RuleFor(x => x.Gender)
            .NotNull().WithMessage("Please select Male or Female.")
            .Must(g => g is Gender.Male or Gender.Female or Gender.Unspecified)
            .WithMessage("Please select Male or Female.");

    }

}




