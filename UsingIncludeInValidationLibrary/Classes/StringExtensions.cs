namespace UsingIncludeInValidationLibrary.Classes;
public static class StringExtensions
{
    public static string JoinWithLastSeparator(this string[] sender, string separator = " and ")
        => string.Join(", ", sender.Take(sender.Length - 1)) + (((sender.Length <= 1) ? "" : separator) +
                                                                sender.LastOrDefault());
}
