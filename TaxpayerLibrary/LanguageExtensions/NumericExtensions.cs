

namespace TaxpayerLibrary.LanguageExtensions;

public static partial class StringExtensions
{
    public static bool IsInteger(this string sender)
    {
        foreach (var c in sender)
        {
            if (c is < '0' or > '9') return false;
        }

        return true;
    }

    public static bool IsInteger1(this string sender) => sender.All(char.IsAsciiDigit);
    public static bool IsInteger2(this string sender) => int.TryParse(sender, out _);
    public static bool IsNotInteger(this string sender) => !sender.IsInteger();
}
