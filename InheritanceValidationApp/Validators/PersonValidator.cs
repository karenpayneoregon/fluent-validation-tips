using FluentValidation;
using InheritanceValidationApp.Models;

namespace InheritanceValidationApp.Validators;
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Email).NotNull();
        RuleFor(x => x.DateOfBirth).GreaterThan(DateTime.MinValue);
    }
}