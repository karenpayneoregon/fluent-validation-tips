using ValidationLibrary.Models;
using ValidationLibrary.Validators;

namespace PasswordMatchApp.Classes;

public class Login
{
    /// <summary>
    /// Responsible for prompting the user for their username and password
    /// </summary>
    /// <returns>A Person and if valid</returns>
    /// <remarks>
    /// The only reason email is here is that the validation library requires it
    /// </remarks>
    public static (Person person, bool valid) LoginUser()
    {
        var userName = Prompts.UserNamePrompt("User Name");
        var password = Prompts.PasswordPrompt("Password");
        var passwordConfirmation = Prompts.PasswordPrompt("Password Confirmation");

        // Create a Person instance to validate
        Person person = new()
        {
            UserName = userName,
            Password = password,
            PasswordConfirmation = passwordConfirmation,
            // for this code sample we do not care about email
            EmailAddress = "abc@gmail.com"
        };

        PersonValidator validator = new();
        // Perform validation against user input
        var validate = validator.Validate(person);

        return (person, validate.IsValid);
    }

    /// <summary>
    /// Determines if the user wants to try again or the credentials are valid
    /// </summary>
    public static (Person person, bool isValid, bool tryAgain) GetCredentials()
    {
        var (person, valid) = LoginUser();
        if (valid == false)
        {

            if (Prompts.Question("Try again?"))
            {
                return (person, false, true);
            }
        }
        return (person, true, false);
    }
}