using UsingIncludeInValidationLibrary.Interfaces;
#pragma warning disable CS8769 // Nullability of reference types in type of parameter doesn't match implemented member (possibly because of nullability attributes).
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace UsingIncludeInValidationLibrary.Models;

public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Address Address { get; set; }
    string IFormattable.ToString(string format, IFormatProvider formatProvider)
        => $"{FirstName} {LastName}";
}