# About

Basic `FluentValidation` Razor pages example

## ⚙️ First run

Open appsettings.json and set  `EntityConfiguration.CreateNew` to `true` to create the database and seed it with some data. Run then set `EntityConfiguration.CreateNew` to `false` to use the existing database.


# Specifics

- Add a reference to [FluentValidation.AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore)
- In Program.cs add the last two line

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<IValidator<Person>, PersonValidator>();
        builder.Services.AddFluentValidationAutoValidation();
```

- Add your model, in this case Person

```csharp
public partial class Person
{
    public int PersonId { get; set; }
    [Display(Name = "First")]
    public string FirstName { get; set; }
    [Display(Name = "Last")]
    public string LastName { get; set; }
    [Display(Name = "Email")]
    public string EmailAddress { get; set; }
}
```

- Create a validator e.g.

```csharp
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
    }
}
```

- Add a private instance of the validator to the page, in this case the create page.

```csharp
private IValidator<Person> _validator;
```

- Setup in the page constructor

```csharp
public CreateModel(Data.Context context, IValidator<Person> validator)
{
    _context = context;
    _validator = validator;
}
```

Run the app, try creating a new Person with missing properties for, in this case Person.

:pushpin:  For practice, implement the above in the Edit Page.