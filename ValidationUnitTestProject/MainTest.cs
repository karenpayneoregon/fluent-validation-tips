using FluentValidation.Results;
using ValidationLibrary.Models;
using ValidationLibrary.Validators;
using ValidationUnitTestProject.Base;
using ValidationUnitTestProject.Extensions;

using static ValidationUnitTestProject.Base.Trait;

namespace ValidationUnitTestProject;

/// <summary>
/// Represents a test class containing unit tests for validating various entities 
/// such as <see cref="Person"/>, 
/// <see cref="Employee"/>, and <see cref="Human"/>.
/// </summary>
/// <remarks>
/// This class inherits from <see cref="TestBase"/> and 
/// utilizes FluentValidation for validation logic. It includes multiple test methods 
/// to ensure the correctness of validation rules defined in the corresponding validators.
/// </remarks>
[TestClass]
public partial class MainTest : TestBase
{
    [TestMethod]
    [TestTraits(GeneralValidation)]
    public void PerfectPersonTest()
    {
        // arrange
        var person = PersonInstance;

        PersonValidator validator = new();

        // act
        ValidationResult result = validator.Validate(person);

        //result.ShowErrorMessage();
        // assert
        Assert.IsTrue(result.IsValid);

    }

    [TestMethod]
    [TestTraits(GeneralValidation)]
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
    [TestTraits(GeneralValidation)]
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
    [TestTraits(GeneralValidation)]
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
    [TestTraits(GeneralValidation)]
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
    [TestTraits(GeneralValidation)]
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

    [TestMethod] 
    [TestTraits(GeneralValidation)]
    public void ValidHumanBirthDate()
    {
        Human human = HumanInstance;
        HumanValidator validator = new();
        ValidationResult result = validator.Validate(human);

        Assert.IsTrue(result.IsValid);

    }
    [TestMethod]
    [TestTraits(GeneralValidation)]
    public void InvalidHumanBirthDate()
    {
        Human human = HumanInstance;
        
        human.BirthDate = new DateOnly(2025, 1, 1);
        HumanValidator validator = new();
        ValidationResult result = validator.Validate(human);

        Assert.IsTrue(result.IsValid);

    }
}