using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FluentWebApplication.Classes;
internal static partial class StringExtensions
{
    [DebuggerStepThrough]
    public static string SplitPascalCase(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    public static string CleanDisplayName(this string sender) =>
        sender.SplitPascalCase()
            .Replace("’", "")
            .Replace("'", "");
    
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CaseRegEx();
}