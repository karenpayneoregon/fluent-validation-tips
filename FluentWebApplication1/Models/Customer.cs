
#nullable disable
using System.ComponentModel.DataAnnotations;
using WebValidationLibrary1.Interfaces;
using WebValidationLibrary1.Models;
// ReSharper disable NotNullOrRequiredMemberIsNotInitialized
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentWebApplication1.Models;
/// <summary>
/// Represents a customer with personal and identification details.
/// </summary>
/// <remarks>
/// This class includes properties for storing customer information such as name, date of birth,
/// social security number, gender, and identification details. It is designed to be used in 
/// scenarios where customer data needs to be validated and processed.
/// </remarks>
public class Customer : INames, IGender, IBirthDate
{
    public int Id { get; set; }
    
    [Display(Name = "Birth date")]
    public DateOnly? DateOfBirth { get; set; }

    [Display(Name = "Social Security Number")]
    public string SocialSecurityNumber { get; set; }

    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Display(Name = "Middle name")]
    public string MiddleName { get; set; }

    [Display(Name = "Last name")]
    public string LastName { get; set; } 

    public Gender? Gender { get; set; }

    public override string ToString() => $"{FirstName} {LastName}  {Gender}";

}