using ValidationLibrary;


// ReSharper disable once CheckNamespace - do not change
namespace ValidationUnitTestProject;

public partial class MainTest
{


    /// <summary>
    /// Perform any initialize for the class
    /// </summary>
    /// <param name="testContext"></param>
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
    }

    protected Person PersonInstance = new()
    {
        UserName = "billyBob",
        Password = "my@Password1",
        EmailAddress = "billyBob@gmailcom",
        PasswordConfirmation = "my@Password1"
    };

    protected Employee EmployeeInstance = new Employee()
    {
        UserName = "111111",
        Password = "my@Password1",
        PasswordConfirmation = "my@Password1",
        EmailAddress = "billyBob@gmail.met",
        Manager = "Jim Adams"
    };
}