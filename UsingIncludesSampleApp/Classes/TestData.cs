using UsingIncludesSampleApp.Models;
using ValidationLibrary1.Interfaces;
using ValidationLibrary1.Models;

namespace UsingIncludesSampleApp.Classes;

public static class TestData
{
    public static IEnumerable<IPerson> MockedData()
    {
        return
        [
            new Person
            {
                Id = 1, FirstName = "Alice", LastName = "Johnson", Gender = Gender.Female,
                DateOfBirth = new DateTime(1990, 5, 12)
            },
            new Customer
            {
                Id = 2, FirstName = "Bob", LastName = "Smith", Gender = Gender.Male,
                DateOfBirth = new DateTime(1985, 11, 23)
            },
            new Person
            {
                Id = 3, FirstName = "Charlie", LastName = "Brown", Gender = Gender.Other,
                DateOfBirth = new DateTime(1909, 2, 3)
            },
            new Person
            {
                Id = 4, FirstName = "Diana", LastName = "Miller", Gender = Gender.Female,
                DateOfBirth = new DateTime(1995, 7, 8)
            },
            new Customer
            {
                Id = 5, FirstName = "", LastName = "Williams", Gender = Gender.Male,
                DateOfBirth = new DateTime(1988, 9, 15)
            }
        ];
    }
}