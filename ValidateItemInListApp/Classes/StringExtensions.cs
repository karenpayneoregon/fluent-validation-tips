using System.Text.RegularExpressions;

namespace ValidateItemInListApp.Classes;
internal static class StringExtensions
{
    /// <summary>
    /// For Spectre.Console which sees brackets in [dbo].[Contacts] as colors
    /// </summary>
    public static string RemoveDoubleQuotes(this string sender)
        => sender.Replace("[", "").Replace("]", "");

    private static readonly Regex Whitespace = new(@"\s+");

    public static string Flatten(this string value)
        => value is null or "" ?
            value :
            Whitespace.Replace(value.Trim(), " ");

    public static string StripCodes(this string sender)
        => Regex.Replace(sender, @"\[[^]]*\]", "")
            .Flatten();

    /// <summary>
    /// Spectre.Console  Add [ to [ and ] to ] so Children[0].Name changes to Children[[0]].Name
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleEscape(this string sender) 
        => Markup.Escape(sender);

    /// <summary>
    /// Spectre.Console Removes markup from the specified string.
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleRemove(this string sender)
        => Markup.Remove(sender);
}
