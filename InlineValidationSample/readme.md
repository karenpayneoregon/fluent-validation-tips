# About

This project demonstrates using fluent validation inline InlineValidator which places property rules in the model rather than a dedicated validator.

## Models

```csharp
public enum Gender
{
    Male,
    Female
}

public class Person : IHuman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }

    public static readonly InlineValidator<Person> Validator = new()
        {
            v => v.RuleFor(x => x.Title)
                .In(ValidationHelpers.Titles),
            v => v.RuleFor(x => x.FirstName).NotEmpty()
                .WithMessage("{PropertyName} is required"),
            v => v.RuleFor(x => x.LastName).NotEmpty()
                .WithMessage("{PropertyName} is required"),
            v => v.RuleFor(x => x.Gender)
                .NotNull()

        };

}
```

## Special rules

For `Person.Title` rules are passed to an extension method which reads valid options from a json file shown below.

Note that `ContactTypes` can be used for an Employee type.

```json
{
  "Titles": [
    "Mr.",
    "Miss",
    "Mrs."
  ],
  "ContactTypes": [
    "Accounting Manager.",
    "Assistant Sales Agent",
    "Assistant Sales Representative",
    "Marketing Assistant",
    "Marketing Manager",
    "Order Administrator",
    "Owner",
    "Owner/Marketing Assistant",
    "Sales Agent",
    "Sales Associate",
    "Sales Manager",
    "Sales Representative",
    "Vice President, Sales"
  ]
}
```