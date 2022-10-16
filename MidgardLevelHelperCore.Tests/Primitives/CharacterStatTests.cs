using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests.Primitives
{
    public class CharacterStatTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => _ = new CharacterStat(name, 1));
        }
    }
}
