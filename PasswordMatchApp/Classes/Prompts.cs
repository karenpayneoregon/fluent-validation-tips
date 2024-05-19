namespace PasswordMatchApp.Classes;

public class Prompts
{
    private static List<string> QuestionOptions => ["Y", "N"];
    private static string promptColor => "[cyan]";
    private static string inputColor => "white";
    public static string UserNamePrompt(string text) => AnsiConsole.Prompt(
        new TextPrompt<string>($"Enter {promptColor}{text}[/]?")
            .PromptStyle(inputColor)
            .AllowEmpty());
    public static string PasswordPrompt(string text) => AnsiConsole.Prompt(
        new TextPrompt<string>($"Enter {promptColor}{text}[/]?")
            .PromptStyle(inputColor)
            .Secret()
            .AllowEmpty());

    private static string Continue(string questionText, string color = "green") =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[{color}]{questionText}[/] {string.Join(",", QuestionOptions)}")
                .PromptStyle("cyan")
                .DefaultValue("y")
                .ValidationErrorMessage($"[red]Valid responses[/] [white]{string.Join(",", QuestionOptions)}[/] {promptColor}or press ENTER for default[/]")
                .Validate(text => QuestionOptions.Contains(text, StringComparer.CurrentCultureIgnoreCase) switch
                {
                    false => ValidationResult.Error("[red]Must be[/] [yellow]y[/] [red]or[/] [yellow]n[/]"),
                    _ => ValidationResult.Success()
                }));

    public static bool Question(string questionText, string color = "green") =>
        Continue(questionText, color).ToLower() == "y";

}