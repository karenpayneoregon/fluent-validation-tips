
using System.Text.RegularExpressions;

namespace FluentWebApplication1.Classes;


/// <summary>
/// Provides extension methods for various utility operations.
/// </summary>
public static partial class Extensions
{

    /// <summary>
    /// Determines whether the specified string is a valid Social Security Number (SSN).
    /// </summary>
    /// <param name="value">The string to validate as a Social Security Number.</param>
    /// <returns>
    /// <c>true</c> if the specified string is a valid SSN; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method validates the format and content of a Social Security Number (SSN) based on the following rules:
    /// - Prevents commonly encountered fake or forged values.
    /// - Ensures the SSN does not contain all matching digits for every field.
    /// - Disallows specific invalid SSNs such as "123-45-6789", "219-09-9999", and "078-05-1120".
    /// - Ensures the SSN does not begin with "666", "000", or any value between "900-999".
    /// - Validates that the Group Number is not "00".
    /// - Validates that the last four digits are not "0000".
    /// </remarks>
    public static bool IsValidSocialSecurityNumber(string value) =>
        !string.IsNullOrEmpty(value) && SocialSecurityNumberRegex().IsMatch(value.Replace("-", ""));

    [GeneratedRegex(@"^(?!\b(\d)\1+\b)(?!123456789|219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$")]
    private static partial Regex SocialSecurityNumberRegex();
}

