using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        Include(new UserNameValidator());
        Include(new PasswordValidator());
        Include(new EmailAddressValidator());
        Include(new PhoneNumberValidator());
    }
}

