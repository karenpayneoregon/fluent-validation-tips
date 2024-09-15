using UsingIncludeInValidationLibrary.Interfaces;
using UsingIncludeInValidationLibrary.Models;

namespace UsingIncludeInValidationLibrary.Classes;
public class MockedData
{
    public static List<IPerson> List()
    {
        List<IPerson> people =
        [
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(1790, 12, 1),
                Address = new Address
                {
                    Line1 = "123 Main St",
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "USA",
                    Postcode = "12345"
                }
            },

            new Citizen
            {
                Id = 1,
                FirstName = "Anne",
                LastName = "Doe",
                BirthDate = new DateOnly(1969, 1, 11),
                Since = new DateOnly(2020, 1, 1),
                Address = new Address
                {
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "USA"
                }
            }
        ];
        return people;
    }
}
