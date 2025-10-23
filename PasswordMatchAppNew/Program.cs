using PasswordMatchAppNew.Classes;
using Spectre.Console;
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
                AnsiConsole.MarkupLine($"[deeppink3_1]{p.UserName}[/] has validation errors:");
                foreach (var error in result.Errors)
                {
                    AnsiConsole.MarkupLine($" - {error.PropertyName}: {error.ErrorMessage}");
                }
                Console.WriteLine();
            }
        }

        SpectreConsoleHelpers.ExitPrompt();
    }

    internal static List<Person> People() =>
    [
        new Person
        {
            UserName = "karenp",
            EmailAddress = "karenp@example.com",
            Password = "Password13!",
            PasswordConfirmation = "Password123!",
            PhoneNumber = "555-123-4567"
        },

        new Person
        {
            UserName = "johns",
            EmailAddress = "johns@example.com",
            Password = "SecurePass456!",
            PasswordConfirmation = "SecurePass456!",
            PhoneNumber = "555-234-5678"
        },

        new Person
        {
            UserName = "maryt",
            EmailAddress = "maryt@example.com",
            Password = "@MyPass789",
            PasswordConfirmation = "@MyPass789!",
            PhoneNumber = "555-345-6789"
        },

        new Person
        {
            UserName = "alexb",
            EmailAddress = "alexb@example.com",
            Password = "StrongOne101!",
            PasswordConfirmation = "StrongOne101!",
            PhoneNumber = "555-456-7890"
        }
    ];
}
