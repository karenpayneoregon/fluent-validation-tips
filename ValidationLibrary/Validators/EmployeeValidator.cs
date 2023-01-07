using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        Include(new UserNameValidator());
        Include(new PasswordValidator());
        Include(new EmailAddressValidator());
        Include(new ManagerValidator());
        RuleFor(person => person.Manager)
            .NotEmpty();
    }
}