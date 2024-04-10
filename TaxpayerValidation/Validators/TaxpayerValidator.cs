using FluentValidation;
using TaxpayerValidation.LanguageExtensions;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Validators;

public class TaxpayerValidator : AbstractValidator<Taxpayer>
{
    public TaxpayerValidator()
    {
        

        Include(new FirstLastNameValidator());
        
        Transform(
                from: customer => customer.SSN, 
                to: value => value.IsSocialSecurityNumberValid())
            .Must(value => value)
            .WithMessage("SSN is required and must be valid");


        RuleFor(x => x.PIN).MinimumLength(4).WithMessage("Must be four numbers");
        RuleFor(x => x.StartDate).BirthDateRule();
    }
}