using FluentValidation;
using InlineValidationSample.Classes;
using InlineValidationSample.LanguageExtensions;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace InlineValidationSample.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        Include(new IdentifierValidator());
        Include(new FirstLastNameValidator());

        RuleFor(x => x.Title)
            .In(ValidationHelpers.ContactTypes);

    }
}