
using System.Text.RegularExpressions;

namespace ValidationUnitTestProject.Extensions;

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

    /// <summary>
    /// Determines whether the specified string represents a valid integer.
    /// </summary>
    /// <param name="input">The string to evaluate.</param>
    /// <returns>
    /// <see langword="true"/> if the string represents a valid integer, including optional '+' or '-' signs; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method checks for the presence of numeric characters and handles optional '+' or '-' signs. 
    /// It excludes strings containing letters or invalid numeric formats.
    /// </remarks>
    public static bool IsInteger3(this string input)
    {

        foreach (char c in input)
        {
            if (char.IsLetter(c))
                return false;
        }

        for (var index = 0; index < input.Length; index++)
        {
            if (!char.IsDigit(input[index]) && input[index] != '+' && input[index] != '-') continue;
            int start = index;

            // Handle optional +/-
            if (input[index] == '+' || input[index] == '-')
            {
                index++;
                if (index >= input.Length || !char.IsDigit(input[index]))
                    continue; // Not a valid number start
            }

            var hasDigits = false;
            while (index < input.Length && char.IsDigit(input[index]))
            {
                hasDigits = true;
                index++;
            }

            if (hasDigits)
                return true; 

            index = start;
        }

        return false;
    }
}
