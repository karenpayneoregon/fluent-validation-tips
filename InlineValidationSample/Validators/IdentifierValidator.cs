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
            .WithMessage(( _, index) =>
                $"Index {index} is not a valid " +
                "{PropertyName}.");
    }
}



