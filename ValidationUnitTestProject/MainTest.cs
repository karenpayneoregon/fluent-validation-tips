using FluentValidation.Results;
using ValidationLibrary.Models;
using ValidationLibrary.Validators;
using ValidationUnitTestProject.Base;
using ValidationUnitTestProject.Extensions;

namespace ValidationUnitTestProject;

[TestClass]
public partial class MainTest : TestBase
{
    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void PerfectPersonTest()
    {
        // arrange
        var person = PersonInstance;

        PersonValidator validator = new();

        // act
        ValidationResult result = validator.Validate(person);

        result.ShowErrorMessage();
        // assert
        //Assert.IsTrue(result.IsValid);

    }

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void MissingUserNameTest()
    {
        // arrange
        var person = EmployeeInstance;

        person.UserName = null;

        PersonValidator validator = new();

        // act
        ValidationResult result = validator.Validate(person);


        // assert
        Assert.IsTrue(result.HasErrorMessage("'User Name' must not be empty."));

    }

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void InvalidPhoneNumberTest()
    {
        // arrange
        var person = EmployeeInstance;

        person.PhoneNumber = "11-999";

        PersonValidator validator = new();

        // act
        ValidationResult result = validator.Validate(person);

        // assert
        Assert.IsTrue(result.HasErrorMessage("Invalid phone number"));

    }

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void PasswordMismatchTest()
    {
        // arrange
        var person = PersonInstance;
        person.PasswordConfirmation = "password";

        PersonValidator validator = new();

        // act
        ValidationResult result = validator.Validate(person);

        // assert
        var test = result.Errors.FirstOrDefault(failure => (StatusCodes)failure.CustomState == StatusCodes.PasswordsMisMatch);
        Assert.IsNotNull(test);
    }

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void PerfectEmployeeTest()
    {
        // arrange
        Employee employee = EmployeeInstance;

        EmployeeValidator validator = new();

        // act
        ValidationResult result = validator.Validate(employee);

        // assert
        Assert.IsTrue(result.IsValid);
    }

    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void InvalidManager()
    {
        // arrange
        Employee employee = EmployeeInstance;

        employee.Manager = "Kim Gales";

        EmployeeValidator validator = new();

        // act
        ValidationResult result = validator.Validate(employee);

        // assert
        Assert.IsFalse(result.IsValid);

    }
}