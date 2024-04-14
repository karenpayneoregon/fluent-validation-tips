using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace InlineValidationSample.Classes;

public static partial class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PrintCyan([CallerMemberName] string methodName = null)
    {
        string SplitCase(string sender) =>
            string.Join(" ", SplitterRegex().Matches(sender)
                .Select(m => m.Value));

        AnsiConsole.MarkupLine($"[cyan]{SplitCase(methodName)}[/]");
        Console.WriteLine();
    }

    [GeneratedRegex("([A-Z][a-z]+)")]
    private static partial Regex SplitterRegex();
}