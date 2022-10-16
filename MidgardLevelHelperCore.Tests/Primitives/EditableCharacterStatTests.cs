using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests.Primitives
{
    public class EditableCharacterStatTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => _ = new EditableCharacterStat(name, 1));
        }
    }
}
