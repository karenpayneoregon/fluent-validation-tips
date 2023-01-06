# FluentValidation tips

[FluentValidation](https://docs.fluentvalidation.net/en/latest/) is a popular .NET library for building strongly-typed validation rules. You can use this library to replace [Data Annotations](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-7.0) in your web application or applications that do not natively support Data Annotations. It also provides an easy way to create validation rules for the properties in your models/classes, taking out the complexity of validation.

The provided documentation allows a developer get up to speed quickly although it's easy to miss some of the nuances to stream line validation code.

Let's look at setting validation for the following class.

```csharp
public class Person
{
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}
```

By the docs the following is all that is needed to setup rules for each property.

```csharp
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
```

To use the `PersonValidator`, create an instance of the `Person` class with data that validates correctly.

```csharp
Person person = new()
{
    UserName = "billyBob",
    Password = "my@Password",
    EmailAddress = "billyBob@gmailcom",
    PasswordConfirmation = "my@Password1"
};
```

Create an instance of `PersonValidator` followed by calling the `Validate` method passing in the person.

```csharp
PersonValidator validator = new();
ValidationResult result = validator.Validate(person);
```

Next

```csharp
if (result.IsValid)
{
    // all properties have valid data
}
else
{
    // one or more properties failed to validate, 
    // iterate through result.Errors to create a message to the user
}
```

# ASP.NET 

See the FluentValidation [documentation](https://docs.fluentvalidation.net/en/latest/aspnet.html) which describe several approaches to implement with dependency injection.


# Tips

Above validation rules are setup in one class

```csharp
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
```

Using [Include](https://docs.fluentvalidation.net/en/latest/including-rules.html) method. Simple example, create an Employee class which inherits Person class where the Employee class has the same properties as the Person class along with a property Manager.

```csharp
public class Employee : Person
{
    public string Manager { get; set; }
}
```

The Include method allows showing rules e.g.

Rule for `UserName` which can be used for Person and Employee

```csharp
public class UserNameValidator : AbstractValidator<Person>
{
    public UserNameValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);
    }
}
```

Create a validator class for EmailAddress which has a builtin Email Address validator but as per the documention only checks to see if the email address has a `@` symbol. So a tip in a tip, slip in data annotaions attribute [EmailAddressAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.emailaddressattribute?view=net-7.0). 

> **Note**
> There is not one way to validate an email address that can satisfy all developers so decide what works best for you and implement in the class below.


```csharp
public class EmailAddressValidator : AbstractValidator<Person>
{
    public EmailAddressValidator()
    {
        RuleFor(person => person.EmailAddress)
            .Must((person, b) => new EmailAddressAttribute().IsValid(person.EmailAddress));
    }
}
```

Password confirmation

```csharp
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
```

**Setup a Person validator using Include**

```csharp
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new UserNameValidator());
        Include(new EmailAddressValidator());
        Include(new PasswordValidator());
    }
}
```

**Setup a Employee validator using Include**

First step is to create a validator class to validate there is a manager for an employee.

> **Note**
> Manager names are hard code, consider obtaining manager names from a cached data source.

```csharp
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
```

Next create the Employee validator

```csharp
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
```














