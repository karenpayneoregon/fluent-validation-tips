using System.Diagnostics;
using System.Text.RegularExpressions;

namespace InlineValidationSample1.LanguageExtensions;
internal static partial class StringExtensions
{
    [DebuggerStepThrough]
    public static string SplitCase(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CaseRegEx();
}
