using System.Text;
using System.Text.RegularExpressions;

namespace TaxpayerValidation.LanguageExtensions;
public static partial class StringExtensions
{
    /// <summary>
    /// Splits pascal case, so "FooBar" would become "Foo Bar".
    /// </summary>
    /// <remarks>
    /// Pascal case strings with periods delimiting the upper case letters,
    /// such as "Address.Line1", will have the periods removed.
    /// </remarks>
    public static string SplitPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var retVal = new StringBuilder(input.Length + 5);

        for (int index = 0; index < input.Length; ++index)
        {
            var currentChar = input[index];
            if (char.IsUpper(currentChar))
            {

                if ((index > 1 && !char.IsUpper(input[index - 1])) 
                    || (index + 1 < input.Length && !char.IsUpper(input[index + 1])))
                {
                    retVal.Append(' ');
                }

            }

            if (!Equals('.', currentChar) || index + 1 == input.Length || !char.IsUpper(input[index + 1]))
            {
                retVal.Append(currentChar);
            }
        }

        return retVal.ToString().Trim();
    }
    /// <summary>
    /// Extreme validation for social security number
    /// </summary>
    /// <param name="ssn">value to validate</param>
    /// <returns></returns>
    /// <remarks>
    /// For simple validation see BaseDataValidatorLibrary.CommonRules.SocialSecurityAttribute
    /// </remarks>
    public static bool IsSocialSecurityNumberValid(this string ssn)
    {
        return !string.IsNullOrWhiteSpace(ssn) && 
               new Regex(@"^(?!\b(\d)\1+-(\d)\1+-(\d)\1+\b)(?!123-45-6789|219-09-9999|078-05-1120)(?!666|000|9\d{2})\d{3}-(?!00)\d{2}-(?!0{4})\d{4}$")
            .IsMatch(ssn);
    }

    /// <summary>
    /// For demonstration only, for a real application use a mask in the database table based on user permissions,
    /// see Others\readme.md
    /// </summary>
    public static string MaskSsn(this string ssn, int digitsToShow = 4, char maskCharacter = 'X')
    {
        if (string.IsNullOrWhiteSpace(ssn)) return string.Empty;
        if (ssn.Contains("-")) ssn = ssn.Replace("-", string.Empty);
        if (ssn.Length != 9) throw new ArgumentException("SSN invalid length");
        if (ssn.IsNotInteger()) throw new ArgumentException("SSN not valid");

        const int ssnLength = 9;
        const string separator = "-";

        int maskLength = ssnLength - digitsToShow;
        int output = int.Parse(ssn.Replace(separator, string.Empty).Substring(maskLength, digitsToShow));

        var format = string.Empty;
        for (var index = 0; index < maskLength; index++)
        {
            format += maskCharacter;
        }

        for (var index = 0; index < digitsToShow; index++)
        {
            format += "0";
        }

        format = format.Insert(3, separator).Insert(6, separator);
        format = $"{{0:{format}}}";

        return string.Format(format, output);

    }


}
