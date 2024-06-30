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
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _title;
    private DateOnly _birthDate;
    private Gender _gender;

    public int Id
    {
        get => _id;
        set
        {
            if (value == _id) return;
            _id = value;
            OnPropertyChanged();
        }
    }
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged();
        }
    }
    public string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged();
        }
    }
    public string Title
    {
        get => _title;
        set
        {
            if (value == _title) return;
            _title = value;
            OnPropertyChanged();
        }
    }
    public DateOnly BirthDate
    {
        get => _birthDate;
        set
        {
            if (value.Equals(_birthDate)) return;
            _birthDate = value;
            OnPropertyChanged();
        }
    }
    public Gender Gender
    {
        get => _gender;
        set
        {
            if (value == _gender) return;
            _gender = value;
            OnPropertyChanged();
        }
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

        };



    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}