// ReSharper disable once CheckNamespace
namespace ValidationUnitTestProject;

public partial class NorthWindTest
{
    [TestInitialize]
    public void Initialization()
    {

    }

    /// <summary>
    /// Perform any initialize for the class
    /// </summary>
    /// <param name="testContext"></param>
    [ClassInitialize()]
    public static void ClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
    }

}