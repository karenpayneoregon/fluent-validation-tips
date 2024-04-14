using FluentValidation;
using InlineValidationSample.Interfaces;

namespace InlineValidationSample.Validators;

public class FirstLastNameValidator : AbstractValidator<IHuman>
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