using Xunit;

namespace MidgardLevelHelperCore.Tests
{
    public class WeaponTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new Weapon(name));
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void WeaponCategory_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new Weapon("Test")
            {
                WeaponCategory = null
            });
            Assert.Equal("value", exception.ParamName);
        }
    }
}