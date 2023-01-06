using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ValidationLibrary;
public class Person
{
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}

public class Employee : Person
{
    public string Manager { get; set; }
}

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new UserNameValidator());
        Include(new EmailAddressValidator());
        Include(new PasswordValidator());

    }
}

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

public enum StatusCodes
{
    PasswordsMisMatch
}

public class PasswordValidator : AbstractValidator<Person>
{

    public PasswordValidator()
    {

        RuleFor(person => person.Password.Length)
            .GreaterThan(7);

        RuleFor(person => person.Password)
            .Equal(p => p.PasswordConfirmation)
            .WithState(x => StatusCodes.PasswordsMisMatch);

    }
}

public class UserNameValidator : AbstractValidator<Person>
{
    public UserNameValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);
    }
}

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

public class ManagerValidator : AbstractValidator<Employee>
{
    public ManagerValidator()
    {
        
        List<string> managers = new List<string>() {"Jim Adams", "Mary Jones"};

        RuleFor(emp => emp.Manager)
            .Must((employee, name) => managers.Contains(employee.Manager))
            .WithMessage("Invalid manager name");

    }
}
