using ConfirmPasswordApp.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ConfirmPasswordApp.Models;

/// <summary>
/// Represents a user entity with properties for username, password, and confirmation of the password.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IUser"/> interface, providing required properties for user authentication.
/// </remarks>
public class User : IUser
{
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
}