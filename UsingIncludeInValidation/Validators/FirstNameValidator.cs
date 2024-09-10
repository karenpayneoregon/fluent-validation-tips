using FluentValidation;
using UsingIncludeInValidation.Interfaces;

namespace UsingIncludeInValidation.Validators;

public class FirstNameValidator : AbstractValidator<IPerson>
{
    public FirstNameValidator()
    {
        RuleFor(person => person.FirstName)
            .NotEmpty()
            .MinimumLength(3);
    }
}