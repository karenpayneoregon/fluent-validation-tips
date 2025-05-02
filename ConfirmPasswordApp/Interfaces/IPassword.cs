namespace ConfirmPasswordApp.Interfaces;

public interface IPassword
{
    string Password { get; set; }
    string ConfirmPassword { get; set; }
}