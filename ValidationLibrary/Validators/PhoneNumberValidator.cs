using FluentValidation;
using ValidationLibrary.LanguageExtensions;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class PhoneNumberValidator : AbstractValidator<Person>
{
    public PhoneNumberValidator()
    {
        RuleFor(person => person.PhoneNumber)
            .MatchPhoneNumber();
    }
}