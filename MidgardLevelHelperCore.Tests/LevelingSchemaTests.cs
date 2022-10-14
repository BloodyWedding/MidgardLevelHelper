using Xunit;

namespace MidgardLevelHelperCore.Tests
{
    public class LevelingSchemaTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_TypeCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string type)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new LevelingSchema(type));
            Assert.Equal("type", exception.ParamName);
        }
    }
}