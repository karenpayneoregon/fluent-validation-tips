namespace InlineValidationSample1.Models;
#nullable disable
public class ValidationContainer
{
    /// <summary>
    /// Titles e.g. Mr, Mrs, Miss
    /// </summary>
    public List<string> Titles { get; set; }
    /// <summary>
    /// Various genders
    /// </summary>
    public List<string> Genders { get; set; }

    public Settings Settings { get; set; }
}