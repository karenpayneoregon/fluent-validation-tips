using System.ComponentModel.DataAnnotations;
using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

/// <summary>
/// The is not one email address validation that will satisfy everyone
/// so feel free to change the following.
/// </summary>
public class EmailAddressValidator : AbstractValidator<Person>
{
    public EmailAddressValidator()
    {
        // this only validates an address contains a @ character
        //RuleFor(person => person.EmailAddress).EmailAddress();

        RuleFor(person => person.EmailAddress)
            .Must((person, b) => new EmailAddressAttribute().IsValid(person.EmailAddress));
    }
}