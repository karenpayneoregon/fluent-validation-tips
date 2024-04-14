using FluentValidation;
using InlineValidationSample.Classes;
using InlineValidationSample.LanguageExtensions;

namespace InlineValidationSample.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        Include(new FirstLastNameValidator());

        RuleFor(x => x.Title)
            .In(ValidationHelpers.ContactTypes);

    }
}