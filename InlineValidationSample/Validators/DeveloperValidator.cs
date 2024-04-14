using FluentValidation;
using InlineValidationSample.LanguageExtensions;

using static InlineValidationSample.Classes.ValidationHelpers;

namespace InlineValidationSample.Validators;

public class DeveloperValidator : AbstractValidator<Developer>
{
    public DeveloperValidator()
    {
        Include(new FirstLastNameValidator());
        RuleFor(x => x.Type).In(DeveloperTypes);
    }
}