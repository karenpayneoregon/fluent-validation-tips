using FluentValidation;
using UsingIncludeInValidation.Interfaces;

namespace UsingIncludeInValidation.Validators;

public class LastNameValidator : AbstractValidator<IPerson>
{
    public LastNameValidator()
    {
        RuleFor(person => person.LastName)
            .NotEmpty()
            .MinimumLength(3);
    }
}