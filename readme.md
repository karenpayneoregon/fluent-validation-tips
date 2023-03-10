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

# Predicate Validator

[Predicate Validator](https://docs.fluentvalidation.net/en/latest/custom-validators.html?highlight=IRuleBuilder#predicate-validator) allows a developer to write custom validators. The following sets up a rule for a string property named PhoneNumber to be `xxx-xxxx`


```csharp
public static class Extensions
{
    public static IRuleBuilderOptions<T, string> MatchPhoneNumber<T>(this IRuleBuilder<T, string> rule)
        => rule.Matches(@"^(1-)?\d{3}-\d{4}$").WithMessage("Invalid phone number");
}
```

The validator

```csharp
public class PhoneNumberValidator : AbstractValidator<Person>
{
    public PhoneNumberValidator()
    {
        RuleFor(person => person.PhoneNumber)
            .MatchPhoneNumber();
    }
}
```

Then in this case include the validator in the PersonValidator.

```csharp
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new UserNameValidator());
        Include(new EmailAddressValidator());
        Include(new PasswordValidator());
        Include(new PhoneNumberValidator());

    }
}
```

Run a test.

```csharp
[TestMethod]
[TestTraits(Trait.Validation)]
public void InvalidPhoneNumberTest()
{
    // arrange
    var person = EmployeeInstance;

    person.PhoneNumber = "11-999";

    PersonValidator validator = new();

    // act
    ValidationResult result = validator.Validate(person);

    // assert
    Assert.IsTrue(result.HasErrorMessage("Invalid phone number"));

}
```

# EF Core example

In this example the goal is to validate that in a Category table, prior to saving to the database ensure the category name is unique.


```csharp
public partial class Categories
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
```

The following method will be used in the `CategoryValidator` below.

```csharp
public static class ValidationHelpers
{
    /// <summary>
    /// Validate we are not going to add a duplicate category name
    /// </summary>
    /// <param name="category"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool UniqueName(Categories category, string name)
    {
        Context context = new Context();
        var categoryItem = context.Categories.AsEnumerable()
            .SingleOrDefault(cat =>
                string.Equals(cat.CategoryName.ToLower(), name.ToLower(), StringComparison.OrdinalIgnoreCase));



        if (categoryItem == null)
        {
            return true;
        }

        return categoryItem.CategoryId == category.CategoryId;
    }
}
```

The validator

```csharp
public class CategoryValidator : AbstractValidator<Categories>
{
    public CategoryValidator()
    {
        RuleFor(category => category.CategoryName)
            .Must((cat, x) => 
                ValidationHelpers.UniqueName(cat, cat.CategoryName));
    }
}
```

Unit test

- First test checks to see if there is a category name in the table for Produce which there is.
- Second test checks to see if there is a category name in the table Coffee where there is not.

```csharp
[TestClass]
public partial class NorthWindTest : TestBase
{

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void CategoryNameExistsTest()
    {
        Categories category = new() { CategoryName = "Produce" };

        CategoryValidator validator = new();
        ValidationResult result = validator.Validate(category);

        Assert.IsFalse(result.IsValid);
    }

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void CategoryNameDoesNExistsTest()
    {
        Categories category = new() { CategoryName = "Coffee" };

        CategoryValidator validator = new();
        ValidationResult result = validator.Validate(category);

        Assert.IsTrue(result.IsValid);
    }
}
```



# ASP.NET 

- See the FluentValidation [documentation](https://docs.fluentvalidation.net/en/latest/aspnet.html) which describe several approaches to implement with dependency injection.
- Here is an [excellent example](https://baskarmib.netlify.app/content/posts/2022/12/22/implementing-validations-in-net-core-api/) for implementing in ASP.NET Core


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




# Related

[Validating application data with Fluent Validation](https://github.com/karenpayneoregon/teaching-simple-validation) provides similar code samples along with using a `json` file to store rule data.

```json
{
  "FirstNameSettings": {
    "MinimumLength": 3,
    "MaximumLength": 10,
    "WithName": "First name"
  },
  "LastNameSettings": {
    "MinimumLength": 5,
    "MaximumLength": 30,
    "WithName": "Last name"
  }
}
```

And PreValidation

```csharp
protected override bool PreValidate(ValidationContext<Customer> context, ValidationResult result)
{
    if (context.InstanceToValidate is null)
    {
        result.Errors.Add(new ValidationFailure("", $"Dude, must have a none null instance of {nameof(Customer)}"));
        return false;
    }

    return true;
}
```

# See also

Another [repository](https://github.com/karenpayneoregon/ssn-validator) to check out if there is a need to validate SSN.

# Requires

- Microsoft Visual Studio 2022 17.4.x or higher

# Summary

Using [FluentValidation](https://docs.fluentvalidation.net/en/latest/) is one way to perform validation, may or may not be right for every developer, some may want to use [Data Annotations](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-7.0) or a third party library like [Postsharp](https://www.postsharp.net/).


