using FluentValidation.Results;

namespace ValidationUnitTestProject.Extensions;
internal static class ValidatingHelpers
{
    /// <summary>
    /// Quick way to show error text
    /// </summary>
    public static void ShowErrorMessage(this ValidationResult sender)
    {
        sender.Errors.ForEach(x => Console.WriteLine(x.ErrorMessage));
    }

    /// <summary>
    /// Does Errors contain an entry with <see cref="message"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="message">error message to check for</param>
    /// <returns>true if message exists, false otherwise</returns>
    public static bool HasErrorMessage(this ValidationResult sender, string message)
    {
        return sender.Errors.FirstOrDefault(x => x.ErrorMessage == message) is not null;
    }

}
