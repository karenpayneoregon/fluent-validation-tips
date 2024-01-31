using System.Text.Json;
using ValidateItemInListApp.Classes;
using ValidateItemInListApp.Models;
using ValidateItemInListApp.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ValidateItemInListApp;

/// <summary>
/// X Challenge
/// https://gist.github.com/karenpayneoregon/8640e5b632c410ea7ce0eb3db9732f74
/// </summary>
internal partial class Program
{
    /*
     * First attempt, invalid while second attempt is valid.
     * Note the use of Spectre.Console ability to write json results in colors
     */
    static void Main(string[] args)
    {
        Master master = new()
        {
            FamilyName = "Smith",
            ValidNames = ["Jim", "Mary", "Karen"],
            Children = [new Child { Name = "Mick" }]
        };

        CustomValidator validator = new();
        ValidationResult result = validator.Validate(master);

        Console.WriteLine();

        if (result.IsValid)
        {
            AnsiConsole.MarkupLine("[yellow]Valid[/]");
        }
        else
        {
            SpectreConsoleHelpers.PresentJson(JsonSerializer.Serialize(result));
        }

        master.Children.First().Name = "Mary";

        result = validator.Validate(master);

        Console.WriteLine();
        Console.WriteLine();

        if (result.IsValid)
        {
            AnsiConsole.MarkupLine("[yellow]Valid[/]");
        }
        else
        {
            SpectreConsoleHelpers.PresentJson(JsonSerializer.Serialize(result));
        }

        SpectreConsoleHelpers.ExitPrompt();
    }
}