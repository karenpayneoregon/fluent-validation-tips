using FluentValidation;
using UsingIncludeInValidationLibrary.Interfaces;

namespace UsingIncludeInValidationLibrary.Validators;

public class LastNameValidator : AbstractValidator<IPerson>
{
    public LastNameValidator()
    {
        RuleFor(person => person.LastName)
            .NotEmpty()
            .MinimumLength(3);
    }
}