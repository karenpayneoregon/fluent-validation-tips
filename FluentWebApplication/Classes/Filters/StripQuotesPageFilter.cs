using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentWebApplication.Classes.Filters;

/// <summary>
/// Represents a page filter that removes quotes from model state values during Razor Pages processing.
/// </summary>
/// <remarks>
/// This filter is applied to Razor Pages to sanitize input by stripping quotes from model state values.
/// It implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IPageFilter"/> interface to handle
/// page handler events such as selection, execution, and completion.
/// </remarks>
public sealed class StripQuotesPageFilter : IPageFilter
{
    public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        => ScrubApostrophes(context.ModelState);

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }
    
    /// <summary>
    /// Removes single quotes from all error messages in the provided <see cref="ModelStateDictionary"/>.
    /// </summary>
    /// <param name="modelState">
    /// The <see cref="ModelStateDictionary"/> containing the model state values and errors to be sanitized.
    /// </param>
    /// <remarks>
    /// This method iterates through the model state entries, clears existing error messages, 
    /// and replaces them with sanitized versions where single quotes are removed.
    /// </remarks>
    private static void ScrubApostrophes(ModelStateDictionary modelState)
    {
        foreach (var kvp in modelState)
        {
            var entry = kvp.Value;
            if (!(entry?.Errors.Count > 0)) continue;
            var errors = entry.Errors.ToList();
            entry.Errors.Clear();
            foreach (var err in errors)
            {
                var cleaned = err.ErrorMessage.Replace("'", string.Empty);
                entry.Errors.Add(cleaned);
            }
        }
    }
}