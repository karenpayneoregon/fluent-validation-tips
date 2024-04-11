using FluentValidation;
using TaxpayerLibrary.Models;

namespace TaxpayerLibrary.Validators;

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