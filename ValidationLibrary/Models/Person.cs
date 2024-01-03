using System.ComponentModel.DataAnnotations;

namespace ValidationLibrary.Models;
public class Person
{
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
    public string PhoneNumber { get; set; }
}