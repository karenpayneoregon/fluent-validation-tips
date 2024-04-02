using FluentValidation;
using ValidateBirthDateApp.Interfaces;

namespace ValidateBirthDateApp.Validators;

public class FirstLastNameValidator : AbstractValidator<IPerson>
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