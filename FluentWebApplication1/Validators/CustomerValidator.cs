using FluentValidation;
using FluentWebApplication1.Classes;
using FluentWebApplication1.Models;

namespace FluentWebApplication1.Validators;

public sealed class CustomerValidator : AbstractValidator<Customer>
{

    public CustomerValidator()
    {

        RuleFor(x => x.DateOfBirth).DateRangeNotNullRule();


        //RuleFor(x => x.SocialSecurityNumber)
        //    .NotEmpty().WithMessage("Social Security Number is required.")
        //    .Matches(@"^\d{3}-?\d{2}-?\d{4}$")
        //    .WithMessage("Enter a valid SSN (###-##-####).");

        //RuleFor(x => x.FirstName)
        //    .NotEmpty().WithMessage("First Name is required");

        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("First Name is required...");

        //RuleFor(x => x.MiddleName)
        //    .MaximumLength(100)
        //    .When(x => !string.IsNullOrWhiteSpace(x.MiddleName));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required...")
            .MaximumLength(100);
        
        //RuleFor(x => x.Gender)
        //    .NotNull().WithMessage("Please select Male or Female.")
        //    .Must(g => g == Gender.Male || g == Gender.Female)
        //    .WithMessage("Please select Male or Female.");

        //RuleFor(x => x.DriversLicenseOrDmvId)
        //    .NotEmpty().WithMessage("Driver's license or DMV ID is required.")
        //    .Matches(@"\S+").WithMessage("Driver's license or DMV ID cannot be blank.");

        //RuleFor(x => x.LicenseIssuingState)
        //    .Cascade(CascadeMode.Stop)
        //    .NotEmpty().WithMessage("License issuing state is required.")
        //    .Must(s => UnitedStates.AllowedStates.Contains(s!))
        //    .WithMessage("Please select a valid 2-letter issuing state.");
    }


}

//public class BirthDateValidator : AbstractValidator<Customer>
//{
//    public BirthDateValidator()
//    {
//        RuleFor(p => p.DateOfBirth)
//            .InclusiveBetween(new DateTime(1910, 1, 1), DateTime.Today)
//            .WithMessage("Birthdate must be between 01/01/1910 and today.")
//            .WithName("BirthDate");
//    }
//}


