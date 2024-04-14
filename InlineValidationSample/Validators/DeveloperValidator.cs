using FluentValidation;
using InlineValidationSample.Models;

namespace InlineValidationSample.Validators;

public class DeveloperValidator : AbstractValidator<Employee>
{
    public DeveloperValidator()
    {
        Include(new FirstLastNameValidator());

    }
}