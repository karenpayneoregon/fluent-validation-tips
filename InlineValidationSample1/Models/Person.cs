using System.ComponentModel;
using System.Runtime.CompilerServices;
using FluentValidation;
using InlineValidationSample1.Interfaces;
using InlineValidationSample1.LanguageExtensions;
using static InlineValidationSample1.Classes.ValidationHelpers;
// ReSharper disable UseCollectionExpression
#nullable disable
namespace InlineValidationSample1.Models;

/// <summary>
/// Example of a FluentValidation inline validator
/// </summary>
public class Person : IHuman, INotifyPropertyChanged
{
    #region Properties


    public int Id
    {
        get; set => SetField(ref field, value);
  
    }
    public string FirstName
    {
        get; set => SetField(ref field, value);
    }
    public string LastName
    {
        get; set => SetField(ref field, value);
    }
    public string Title
    {
        get; set => SetField(ref field, value);
    }
    public DateOnly BirthDate
    {
        get; set => SetField(ref field, value);
    }
    public Gender Gender
    {
        get; set => SetField(ref field, value);

    }

    #endregion

    public static readonly InlineValidator<Person> Validator = new()
        {
            // validate against the Titles from Validation.json using ValidatorExtensions.In extension method
            v => v.RuleFor(x => x.Title)
                .In(Titles),
            
            v => v.RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required"),

            v => v.RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required"),

            // validate against the genders from Validation.json
            v => v.RuleFor(x => x.Gender)
                .NotNull()
                .In(GenderTypes),

            // validate against the BirthDateRule extension method
            v => v.RuleFor(x => x.BirthDate)
                .BirthDateRule()
                .WithMessage($"{nameof(BirthDate).SplitCase()} is not a valid date.")

        };


    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new(propertyName));

    /// <summary>
    /// Sets the field to the specified value and raises the <see cref="PropertyChanged"/> event if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the field.</typeparam>
    /// <param name="field">The field to set.</param>
    /// <param name="value">The value to set the field to.</param>
    /// <param name="propertyName">The name of the property. This is optional and will be automatically provided by the compiler.</param>
    /// <returns><c>true</c> if the field was changed; otherwise, <c>false</c>.</returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    
    
}

