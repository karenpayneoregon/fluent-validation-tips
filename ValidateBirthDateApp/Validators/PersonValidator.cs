#nullable disable
using FluentValidation;
using ValidateBirthDateApp.LanguageExtensions;
using ValidateBirthDateApp.Models;

namespace ValidateBirthDateApp.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new FirstLastNameValidator());
        RuleFor(x => x.BirthDate).BirthDateRule();

    }
}