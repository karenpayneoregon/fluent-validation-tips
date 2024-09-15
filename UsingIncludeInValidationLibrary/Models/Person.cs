﻿using UsingIncludeInValidationLibrary.Interfaces;

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