using FluentValidation.Results;
using ValidationLibrary;
using ValidationUnitTestProject.Base;

namespace ValidationUnitTestProject
{
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


            // assert
            Assert.IsTrue(result.IsValid);

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

    }
}
