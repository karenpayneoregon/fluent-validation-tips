using FluentValidation;
using UsingIncludeInValidationLibrary.Interfaces;

namespace UsingIncludeInValidationLibrary.Validators;

public class FirstNameValidator : AbstractValidator<IPerson>
{
    public FirstNameValidator()
    {
        RuleFor(person => person.FirstName)
            .NotEmpty()
            .MinimumLength(3);
    }
}