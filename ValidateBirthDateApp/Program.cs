using ValidateBirthDateApp.Models;
using ValidateBirthDateApp.Validators;
using static ValidateBirthDateApp.Classes.SpectreConsoleHelpers;

namespace ValidateBirthDateApp;

internal partial class Program
{
    static void Main()
    {
        InvalidPerson();
        Console.WriteLine();
        ValidPerson();

        Console.ReadLine();
    }

    private static void InvalidPerson()
    {

        PrintMethod();

        Person person = new()
        {

            BirthDate = new DateOnly(1845, 1, 1)
        };

        Console.WriteLine(ObjectDumper.Dump(person));

        PersonValidator validator = new();
        var validate = validator.Validate(person);
        if (validate.IsValid)
        {
            AnsiConsole.MarkupLine("[green]Valid[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No valid[/]");
            foreach (var failure in validate.Errors)
            {
                AnsiConsole.MarkupLine($"   WithName: [white]{failure.ErrorMessage}[/]");
            }
        }
    }

    private static void ValidPerson()
    {

        PrintMethod();

        Person person = new()
        {
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1980, 1, 1)
        };

        Console.WriteLine(ObjectDumper.Dump(person));


        PersonValidator validator = new();
        var validate = validator.Validate(person);
        if (validate.IsValid)
        {
            AnsiConsole.MarkupLine("[green]Valid[/]");
            
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No valid[/]");
            foreach (var failure in validate.Errors)
            {
                AnsiConsole.MarkupLine($"   WithName: [white]{failure.ErrorMessage}[/]");
            }
        }
    }
}