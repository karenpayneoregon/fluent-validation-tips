namespace IncludeRuleSetsApp.LanguageExtensions;

public static class BoolExtensions
{
    /// <summary>
    /// Converts a <see cref="bool"/> value to its corresponding "Yes" or "No" string representation.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>
    /// A string "Yes" if <paramref name="value"/> is <c>true</c>, otherwise "No".
    /// </returns>
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    
}