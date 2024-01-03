using ValidationLibrary.Models;


// ReSharper disable once CheckNamespace - do not change
namespace ValidationUnitTestProject;

public partial class MainTest
{


    /// <summary>
    /// Perform any initialize for the class
    /// </summary>
    /// <param name="testContext"></param>
    [ClassInitialize()]
    public static void ClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
    }

    protected Person PersonInstance = new()
    {
        UserName = "billyBob",
        Password = "my@Password1",
        EmailAddress = "billyBob@gmailcom",
        PasswordConfirmation = "my@Password1",
        PhoneNumber = "999-1234"
    };

    protected Employee EmployeeInstance = new()
    {
        UserName = "111111",
        Password = "my@Password1",
        PasswordConfirmation = "my@Password1",
        EmailAddress = "billyBob@gmail.met",
        PhoneNumber = "654-1234",
        Manager = "Jim Adams"
    };

    protected Human HumanInstance = new()
    {
        FirstName = "Jean",
        LastName = "Grey",
        BirthDate = DateOnly.FromDateTime(DateTime.Now)
    };


}