namespace ConfirmPasswordApp.Interfaces;

public interface IUser
{
    public int Id { get; set; } 
    string UserName { get; set; }
    string Password { get; set; }
    string ConfirmPassword { get; set; }
}