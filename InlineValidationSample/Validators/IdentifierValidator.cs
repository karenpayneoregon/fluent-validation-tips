using FluentValidation;
using InlineValidationSample.Interfaces;

namespace InlineValidationSample.Validators;

public class IdentifierValidator : AbstractValidator<IEmployee>
{
    public IdentifierValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .WithMessage((element, context) => 
                $"Email for attendee at index {context} is not a valid email address.");
    }
}