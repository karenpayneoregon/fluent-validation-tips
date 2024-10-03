using System.Runtime.CompilerServices;
using Spectre.Console.Json;

namespace InheritanceValidationApp.Classes;

public class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();


        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PresentJson(string json)
    {
        json = json.Replace("\\u0027", "");
        AnsiConsole.Write(
            new JsonText(json)
                .BracesColor(Color.Red)
                .BracketColor(Color.Green)
                .ColonColor(Color.White)
                .CommaColor(Color.Cyan1)
                .StringColor(Color.GreenYellow)
                .NumberColor(Color.White)
                .BooleanColor(Color.Red)
                .MemberColor(Color.Yellow)
                .NullColor(Color.Green));
        AnsiConsole.WriteLine();
    }
}