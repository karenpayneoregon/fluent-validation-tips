using FluentValidation;
using UsingIncludeInValidationLibrary.Interfaces;

namespace UsingIncludeInValidationLibrary.Validators;

public class PersonValidator : AbstractValidator<IPerson>
{
    public PersonValidator()
    {
        Include(new FirstNameValidator());
        Include(new LastNameValidator());
        Include(new BirthDateValidator());
        Include(new AddressValidator());
    }
}