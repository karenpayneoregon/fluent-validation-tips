namespace ValidationLibrary.Interfaces;

public interface IUser
{
    string UserName { get; set; }
    string Password { get; set; }
    string PasswordConfirmation { get; set; }
}