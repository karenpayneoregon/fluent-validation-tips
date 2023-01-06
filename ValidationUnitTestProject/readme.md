# About

![image](assets/OED_UnitTest.png)

![image](assets/Versions.png)

- Base starter unit test project.
- This file may be deleted if there is no need for information provided.
  - The assert folder should be deleted if this file is deleted.
# Microsoft documentation
- [Unit test basics](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2019)
- [Live Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing-intro?view=vs-2019)
- [web load testing](https://docs.microsoft.com/en-us/visualstudio/test/quickstart-create-a-load-test-project?view=vs-2019)

>  **Note** 
Live Unit Testing is only available in Visual Studio Enterprise edition and is supported only in .NET.

## Provides

|Class|Provides   |
| :---         |  :---  |
|TestBase | A place any `initialization code` and `mock-up code` here for unit test methods   |
|TestTraitsAttribute| The ability to setup meaningful [trait attributes](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019) for visual separation of unit test categories  |

# Use the MSTest framework in unit tests

The MSTest framework supports unit testing in Visual Studio. Use the classes and members in the Microsoft.VisualStudio.TestTools.UnitTesting namespace when you are coding unit tests. You can also use them when you are refining a unit test that was generated from code.

- [Microsoft documentation](https://docs.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2019)

# Assertions – Constraint Model

|Assertion |What it does   |
| :---         |  :---  |
| Assert.AreEqual(28, _actualClaim);  | Tests whether the specified values are equal.   |
| Assert.AreNotEqual(28, _actualClaim);  | Tests whether the specified values are unequal. Same as AreEqual for numeric values.  |
| Assert.AreSame(_expectedInitialClaim, _actualInitialClaim); | Tests whether the specified objects both refer to the same object  |
| Assert.AreNotSame(_expectedInitialClaim, _actualInitialClaim); |  Tests whether the specified objects refer to different objects |
| Assert.IsTrue(_isThereEnoughFuel); | Tests whether the specified condition is true  |
| Assert.IsFalse(_isThereEnoughFuel); | Tests whether the specified condition is false  |
| Assert.IsNull(_actualInitialClaim); | Tests whether the specified object is null  |
| Assert.IsNotNull(_actualInitialClaim); | Tests whether the specified object is non-null  |
| Assert.IsInstanceOfType(_actualInitialClaim, typeof(dummyClaim9InitialClaim)); | Tests whether the specified object is an instance of the expected type  |
| Assert.IsNotInstanceOfType(_actualInitialClaim, typeof(dummyClaim9InitialClaim)); | Tests whether the specified object is not an instance of type  |
| StringAssert.Contains(_expectedBellatrixTitle, "Karen"); | Tests whether the specified string contains the specified substring  |
| StringAssert.StartsWith(_expectedBellatrixTitle, "Karen"); | Tests whether the specified string begins with the specified substring  |
| StringAssert.Matches("(281)388-0388", @"(?d{3})?-? *d{3}-? *-?d{4}");  | Tests whether the specified string matches a regular expression  |
| StringAssert.DoesNotMatch("281)388-0388", @"(?d{3})?-? *d{3}-? *-?d{4}");  | Tests whether the specified string does not match a regular expression |
| CollectionAssert.AreEqual(_expectedInitialClaims, _actualInitialClaims);  | Tests whether the specified collections have the same elements in the same order and quantity.  |
| CollectionAssert.AreNotEqual(_expectedInitialClaims, _actualInitialClaims); | Tests whether the specified collections does not have the same elements or the elements are in a different order and quantity.  |
| CollectionAssert.AreEquivalent(_expectedInitialClaims, _actualInitialClaims); | Tests whether two collections contain the same elements.  |
| CollectionAssert.AreNotEquivalent(_expectedInitialClaims, _actualInitialClaims); | Tests whether two collections contain different elements.  |
| CollectionAssert.AllItemsAreInstancesOfType(_expectedInitialClaims, _actualInitialClaims); | Tests whether all elements in the specified collection are instances of the expected type  |
| CollectionAssert.AllItemsAreNotNull(_expectedInitialClaims); |  Tests whether all items in the specified collection are non-null |
| CollectionAssert.AllItemsAreUnique(_expectedInitialClaims); | Tests whether all items in the specified collection are unique  |
| CollectionAssert.Contains(_actualInitialClaims, dummyClaim9); | Tests whether the specified collection contains the specified element |
| CollectionAssert.DoesNotContain(_actualInitialClaims, dummyClaim9) | Tests whether the specified collection does not contain the specified element  |
| CollectionAssert.IsSubsetOf(_expectedInitialClaims, _actualInitialClaims); | Tests whether one collection is a subset of another collection  |
| CollectionAssert.IsNotSubsetOf(_expectedInitialClaims, _actualInitialClaims); | Tests whether one collection is not a subset of another collection  |
| Assert.ThrowsException<ArgumentNullException>(() => new Regex(null)); | ests whether the code specified by delegate throws exact given exception of type T  |

# Deep compares

For comparing complex objects use the following.

- **NuGet package** [CompareNETObjects](https://www.nuget.org/packages/CompareNETObjects) for deep compares on objects and list of objects.
  - [Project site](https://github.com/GregFinzer/Compare-Net-Objects)

# Simple compares

[Enumerable.SequenceEqual Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal?view=net-5.0)



# Example of a complex object



```csharp
namespace AsyncOperations
{
    public partial class Customers : INotifyPropertyChanged
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public int? ContactId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        public virtual Countries CountryIdentifierNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

SQL representation

```sql
SELECT C.CustomerIdentifier, 
       C.CompanyName, 
       C.ContactId, 
       C.Street, 
       C.City, 
       C.Region, 
       C.PostalCode, 
       C.CountryIdentifier, 
       C.Phone, 
       C.Fax, 
       C.ContactTypeIdentifier, 
       C.ModifiedDate, 
       Countries.[Name] AS country, 
       Contacts.FirstName, 
       Contacts.LastName, 
       CT.ContactTitle
FROM Customers AS C
     INNER JOIN Contacts ON C.ContactId = Contacts.ContactId
     INNER JOIN Countries ON C.CountryIdentifier = Countries.CountryIdentifier
     INNER JOIN ContactType AS CT ON C.ContactTypeIdentifier = CT.ContactTypeIdentifier
                                     AND Contacts.ContactTypeIdentifier = CT.ContactTypeIdentifier;
```


