using PasswordMatchAppNew.Classes;
using Spectre.Console;
using Spectre.Console.Json;
using System.Text.Json;
using ValidationLibrary.Models;
using ValidationLibrary.Validators;

namespace PasswordMatchAppNew;
internal partial class Program
{
    static void Main(string[] args)
    {
        // Pseudocode:
        // - Build list of people
        // - For each person:
        //   - Validate with PersonValidator
        //   - If invalid:
        //     - Print the username and all validation errors (property + message)
        // - Prompt to exit

        var people = People();

        foreach (var p in people)
        {
            PersonValidator validator = new();
            var result = validator.Validate(p);

            if (!result.IsValid)
            {
                AnsiConsole.MarkupLine($"[orangered1]{p.UserName}[/] validation errors:");
                foreach (var error in result.Errors)
                {
                    AnsiConsole.MarkupLine($" :small_orange_diamond: {error.PropertyName}: {error.ErrorMessage}");
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine();

        //DisplayValidationErrors();

        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void DisplayValidationErrors()
    {
        var people = People();
        var john = people.First(x => x.UserName == "johns");
        
        PersonValidator validator1 = new();
        var result1 = validator1.Validate(john);
        
        var json = new JsonText(JsonSerializer.Serialize(result1, Indented))
            .BracesColor(Color.Red)
            .BracketColor(Color.Green)
            .ColonColor(Color.White)
            .CommaColor(Color.Cyan1)
            .StringColor(Color.GreenYellow)
            .NumberColor(Color.White)
            .BooleanColor(Color.Red)
            .MemberColor(Color.DeepPink1)
            .NullColor(Color.Green);

        AnsiConsole.Write(new Panel(json).Header("Errors")
            .Collapse()
            .BorderColor(Color.White));
        
    }

    internal static List<Person> People() =>
    [
        new Person
        {
            UserName = "karenp",
            EmailAddress = "karenp@example.com",
            Password = "Password13!",               // passwords do not match
            PasswordConfirmation = "Password123!",
            PhoneNumber = "555-123-4567"
        },

        new Person
        {
            UserName = "johns",
            EmailAddress = "johnsexample.com",      // invalid email address
            Password = "secureass456",              // valid password
            PasswordConfirmation = "secureass456",
            PhoneNumber = "555-234-5678"
        },

        new Person
        {
            UserName = "maryt",
            EmailAddress = "maryt@example.com",
            Password = "@MyPass789",                // passwords do not match
            PasswordConfirmation = "@MyPass789!",
            PhoneNumber = "555-345-6789"
        },

        new Person
        {
            UserName = "alexb",
            EmailAddress = "alexb@example.com",
            Password = "StrongOne101!",
            PasswordConfirmation = "StrongOne101!",
            PhoneNumber = "555x456-7890"            // invalid phone number
        }
    ];

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}
