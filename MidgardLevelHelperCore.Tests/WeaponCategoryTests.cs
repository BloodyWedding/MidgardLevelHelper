using Xunit;

namespace MidgardLevelHelperCore.Tests
{
    public class WeaponCategoryTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => _ = new WeaponCategory(name));
        }
    }
}