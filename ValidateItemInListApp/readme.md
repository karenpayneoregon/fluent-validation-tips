# About

Sample code to validate that a List property contains only valid values.

**Validator**

```csharp
public class CustomValidator : AbstractValidator<Master>
{
    public CustomValidator()
    {
        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .WithMessage($"{nameof(Master.FamilyName)} can not be empty");

        RuleForEach(m => m.Children)
            .SetValidator(m => new ChildValidator(m.ValidNames));
    }
}

public class ChildValidator : AbstractValidator<Child>
{
    public ChildValidator(List<string> validNames)
    {
        RuleFor(c => c.Name)
            .Must(validNames.Contains)
            .WithMessage("Name does not exist in ValidNames");
    }
}
```

**Models**

```csharp
public class Master
{
    public int Id { get; set; }
    public string FamilyName { get; set; }
    public List<string> ValidNames;
    public List<Child> Children;
}

public class Child
{
    public string Name;
    public int Age;
}
```


