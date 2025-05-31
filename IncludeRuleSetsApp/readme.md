# FluentValidation Rule Sets Example

This example demonstrates how to use FluentValidation with rule sets to validate different scenarios.

## Rule Sets

- `Names`: Validates that `FirstName` and `LastName` are not null.
- `Identifier`: Validates that `PersonId` is not equal to 0.
- `BirthDateRule`: Validates that `BirthDate` is a valid date according to a custom rule defined in the `BirthDateRule` extension method.

There may be times that `PersonId` is not required, such as when creating a new person for insertion into a database. In this case, the `Identifier` rule set can be skipped.

```csharp
public class PersonValidator : AbstractValidator<Person>
{

    public PersonValidator()
    {
        RuleSet("Names", () =>
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
        });

        RuleSet("Identifier", () =>
        {
            RuleFor(x => x.PersonId).NotEqual(0);
        });

        RuleSet("Birth", () =>
        {
            RuleFor(x => x.BirthDate).BirthDateRule();
        });


        
    }
}
```
