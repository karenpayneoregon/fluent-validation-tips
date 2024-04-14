using InlineValidationSample.Models;

namespace InlineValidationSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        Person person = new()
        {
            //FirstName = "Jane", 
            LastName = "Adams", 
            //Gender = Gender.Female, 
            //Title = "Miss"
        };

        var validator = Person.Validator.Validate(person);
        if (validator.IsValid == false)
        {
            foreach (var error in validator.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }
        else
        {
            Console.WriteLine("Valid person");
        }

        Console.ReadLine();
    }

}