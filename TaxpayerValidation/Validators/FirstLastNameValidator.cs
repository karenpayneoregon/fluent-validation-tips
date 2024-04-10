using FluentValidation;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Validators;

public class FirstLastNameValidator : AbstractValidator<Taxpayer>
{
    public FirstLastNameValidator()
    {

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(3);

    }
}