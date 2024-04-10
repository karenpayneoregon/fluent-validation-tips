namespace TaxpayerValidation.LanguageExtensions;
public static class NumericExtensions
{
    /// <summary>
    /// Determine if a string can represent an integer
    /// </summary>
    /// <param name="sender">string to assert</param>
    public static bool IsInteger(this string sender)
    {
        foreach (var c in sender)
        {
            if (c is < '0' or > '9') return false;
        }

        return true;
    }

    /// <summary>
    /// Indicates a string value can represent a positive int
    /// </summary>
    /// <param name="sender">string to assert</param>
    public static bool IsNotInteger(this string sender)
        => sender.IsInteger() == false;
}
