using FluentValidation;
using IncludeRuleSetsApp.Models;

namespace IncludeRuleSetsApp;

internal partial class Program
{
    private static void Main(string[] args)
    {

        var validator = new PersonValidator();
        
        var result = validator.Validate(ValidPerson, options => options.IncludeRuleSets("Names", "Identifiers"));
        if (result.IsValid)
        {
            Console.WriteLine("Validation succeeded.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                AnsiConsole.MarkupLine($"[white]Property:[/] {error.PropertyName}, [red]Error:[/] {error.ErrorMessage}");
            }
        }
        AnsiConsole.MarkupLine("[yellow]Continue[/]");

        Console.ReadLine();
    }

    private static Person ValidPerson => new Person
    {
        FirstName = "John",
        LastName = "Doe",
        PersonId = 1
    };

    private static Person MissingIdPerson => new Person
    {
        FirstName = "John",
        LastName = "Doe",
        PersonId = 0
    };

    private static Person MissingNamesPerson => new Person
    {
        PersonId = 10
    };

}