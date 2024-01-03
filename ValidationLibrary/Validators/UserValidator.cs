using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class UserValidator : AbstractValidator<Person>
{
    public UserValidator()
    {
        Include(new UserNameValidator());
        Include(new EmailAddressValidator());
        Include(new PasswordValidator());
    }
}


