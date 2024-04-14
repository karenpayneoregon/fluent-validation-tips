
using InlineValidationSample.Models;

namespace InlineValidationSample.Interfaces;
public interface IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
}