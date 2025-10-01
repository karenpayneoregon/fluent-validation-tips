# About

Demonstrates using FluentValidation [Include](https://docs.fluentvalidation.net/en/latest/including-rules.html) validators as shown below.

See project `ValidationLibrary1` for validators.

```csharp
public class BasePersonValidator : AbstractValidator<IPerson>
{
    public BasePersonValidator()
    {
        Include(new FirstNameValidator());
        Include(new LastNameValidator());
        Include(new BirthDateValidator());
    }
}
```

## BasePersonValidator visualization

```mermaid
classDiagram
    class IPerson {
        +string FirstName
        +string LastName
        +DateTime DateOfBirth
    }

    class AbstractValidator~IPerson~
    class BasePersonValidator
    class FirstNameValidator
    class LastNameValidator
    class BirthDateValidator

    BasePersonValidator --|> AbstractValidator~IPerson~
    FirstNameValidator --|> AbstractValidator~IPerson~
    LastNameValidator --|> AbstractValidator~IPerson~
    BirthDateValidator --|> AbstractValidator~IPerson~

    BasePersonValidator ..> FirstNameValidator : includes
    BasePersonValidator ..> LastNameValidator : includes
    BasePersonValidator ..> BirthDateValidator : includes
```