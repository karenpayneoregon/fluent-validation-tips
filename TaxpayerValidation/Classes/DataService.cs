using Bogus;
using Bogus.Extensions.UnitedStates;
using TaxpayerValidation.Models;


namespace TaxpayerValidation.Classes;

public class DataService
{
    /// <summary>
    /// These are SSN that will validate against an SSN regex validator
    /// </summary>
    /// <returns>One SSN</returns>
    private static string GetRandomSocialSecurityNumber()
    {
        string[] list =
        [
            "501-37-0292", "121-98-8923", "653-58-5894", "353-80-2841", "682-22-2244", 
            "617-83-6902", "304-37-7825", "334-11-8400", "528-99-3191", "264-99-2178", 
            "310-35-8701", "568-99-4748", "673-46-4128", "264-99-3459", "002-80-6718", "031-92-4020"
        ];

        Random rand = new();
        return list[rand.Next(list.Length)];
    }

    /// <summary>
    /// Generate a fake taxpayer for create page
    /// </summary>
    public static Taxpayer BogusTaxpayer()
    {
        Faker faker = new();
        return new Taxpayer()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            SSN = faker.Person.Ssn(),
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            PIN = faker.Random.Replace("####")
        };
    }

}
