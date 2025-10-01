
#nullable disable
using System.ComponentModel.DataAnnotations;

namespace FluentWebApplication1.Models;
/// <summary>
/// Represents a customer with personal and identification details.
/// </summary>
/// <remarks>
/// This class includes properties for storing customer information such as name, date of birth,
/// social security number, gender, and identification details. It is designed to be used in 
/// scenarios where customer data needs to be validated and processed.
/// </remarks>
public class Customer
{
    [Display(Name = "Birth date")]
    public DateOnly? DateOfBirth { get; set; }


    //public string SocialSecurityNumber { get; set; } = string.Empty;

    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Display(Name = "Middle name")]
    public string? MiddleName { get; set; }

    [Display(Name = "Last name")]
    public string LastName { get; set; } 


    //public Gender? Gender { get; set; }

    //public string DriversLicenseOrDmvId { get; set; } = string.Empty;

    //public string? LicenseIssuingState { get; set; }

    //public string? PreferredLanguage { get; set; }
}