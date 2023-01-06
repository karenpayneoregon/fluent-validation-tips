namespace ValidationUnitTestProject.Base
{
    public enum Trait
    {
        /// <summary>
        /// Place holder 
        /// </summary>
        PlaceHolder,
        /// <summary>
        /// Entity Framework Core test
        /// </summary>
        EntityFrameworkCore,
        /// <summary>
        /// Configuration test
        /// </summary>
        Configurations,
        /// <summary>
        /// Controller test
        /// </summary>
        Controller,
        /// <summary>
        /// Service test
        /// </summary>
        Services,
        Validation
    }
    /// <summary>
    /// Declarative class for using Trait enum about for traits on test method.
    /// </summary>
    public class TestTraitsAttribute : TestCategoryBaseAttribute
    {
        private readonly Trait[] _traits;

        public TestTraitsAttribute(params Trait[] traits)
        {
            _traits = traits;
        }

        public override IList<string> TestCategories => _traits.Select(trait => Enum.GetName(typeof(Trait), trait)).ToList();
    }

}