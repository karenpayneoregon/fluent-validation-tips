using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace IncludeRuleSetsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "FluentValidation IncludeRuleSets Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        AnsiConsole.Write(new FigletText("IncludeRuleSets")
                .LeftJustified()
                .Color(Color.Pink1));

        AnsiConsole.Write(new Rule());
    }
}
