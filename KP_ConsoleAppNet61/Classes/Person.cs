using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_ConsoleAppNet61.Classes;
public class Person
{
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);


        RuleFor(person => person.EmailAddress).EmailAddress();
        RuleFor(person => person.Password.Length)
            .GreaterThan(7);

        RuleFor(person => person.Password)
            .Equal(p => p.PasswordConfirmation);

    }
}